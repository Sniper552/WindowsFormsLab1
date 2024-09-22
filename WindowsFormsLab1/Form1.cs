using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsLab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Grammar grammar;
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                // Валидация и ввод терминалов
                var terminals = txtTerminals.Text.Split(' ').ToList();

                // Валидация и ввод нетерминалов
                var nonTerminals = txtNonTerminals.Text.Split(' ').ToList();

                // Валидация и ввод правил
                var rulesInput = txtRules.Text.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                var rules = new Dictionary<string, List<string>>();
                foreach (var rule in rulesInput)
                {
                    var parts = rule.Split(new[] { "->" }, StringSplitOptions.None);
                    if (parts.Length != 2)
                    {
                        MessageBox.Show("Invalid rule format. Use 'NonTerminal -> production'.");
                        return;
                    }
                    var nonTerminal = parts[0].Trim();
                    var productions = parts[1].Trim().Split('|').Select(p => p.Trim()).ToList();
                    rules[nonTerminal] = productions;
                }

                // Валидация и ввод начального символа
                var startSymbol = txtStartSymbol.Text;
                if (!nonTerminals.Contains(startSymbol))
                {
                    MessageBox.Show("Start symbol must be one of the non-terminals.");
                    return;
                }

                // Валидация границ
                int leftBorder, rightBorder;
                if (!int.TryParse(txtLeftBorder.Text, out leftBorder) || !int.TryParse(txtRightBorder.Text, out rightBorder) || leftBorder < 0 || rightBorder < leftBorder)
                {
                    MessageBox.Show("Invalid word size boundaries.");
                    return;
                }

                // Инициализация грамматики
                grammar = new Grammar
                {
                    VT = terminals,
                    VN = nonTerminals,
                    P = rules,
                    S = startSymbol
                };

                // Генерация слов
                GenerateWords(leftBorder, rightBorder);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void GenerateWords(int leftBorder, int rightBorder)
        {
            // Очистка вывода
            txtOutput.Clear();

            List<string> rules = new List<string> { grammar.S };
            HashSet<string> usedSeq = new HashSet<string>();

            while (rules.Count > 0)
            {
                string sequence = rules.Last();
                rules.RemoveAt(rules.Count - 1);

                if (usedSeq.Contains(sequence))
                {
                    continue;
                }
                usedSeq.Add(sequence);

                bool onlyTerm = true;
                for (int i = 0; i < sequence.Length; i++)
                {
                    string symbol = sequence[i].ToString();  // символ как строка
                    if (grammar.VN.Contains(symbol))
                    {
                        onlyTerm = false;
                        foreach (string elem in grammar.P[symbol])
                        {
                            string temp = sequence.Substring(0, i) + elem + sequence.Substring(i + 1);
                            if (temp.Length <= rightBorder + 1)
                            {
                                rules.Add(temp);
                            }
                        }
                    }
                }

                if (onlyTerm && sequence.Length >= leftBorder && sequence.Length <= rightBorder)
                {
                    txtOutput.AppendText(string.IsNullOrEmpty(sequence) ? "lam" + Environment.NewLine : sequence + Environment.NewLine);
                }
            }
        }
        private void btnTestValues_Click(object sender, EventArgs e)
        {
            // Очистить текстовые поля перед заполнением
            txtTerminals.Clear();
            txtNonTerminals.Clear();
            txtRules.Clear();
            txtStartSymbol.Clear();
            txtLeftBorder.Clear();
            txtRightBorder.Clear();

            // Заполнение тестовыми значениями
            txtTerminals.Text = "a b"; 
            txtNonTerminals.Text = "S A"; // Пример нетерминалов

            // Заполнение правил без использования символа '|'
            txtRules.AppendText("S -> aA | bS");
            txtRules.AppendText(Environment.NewLine); // Разделение строки для нового правила
            txtRules.AppendText("A -> aA | a");

            // Стартовый символ
            txtStartSymbol.Text = "S"; // Пример стартового символа

            // Левый и правый предел длины слов
            txtLeftBorder.Text = "2"; // Пример минимальной длины
            txtRightBorder.Text = "5"; // Пример максимальной длины
        }

    }

    public class Grammar
    {
        public List<string> VT { get; set; }  // Терминальные символы
        public List<string> VN { get; set; }  // Нетерминальные символы
        public Dictionary<string, List<string>> P { get; set; }  // Правила продукции
        public string S { get; set; }  // Начальный символ
    }
}
