using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
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
                    var productions = parts[1].Trim()
                        .Split('|')
                        .Select(p => p.Trim() == "lambda" ? "" : p.Trim())  // добавлено преобразование для lambda
                        .ToList();
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
            // Очистка вывода и списка цепочек
            txtOutput.Clear();
            listBoxChains.Items.Clear();

            // Используем очередь, которая будет хранить кортежи (текущая последовательность, шаги генерации)
            List<(string Sequence, string Path)> rules = new List<(string, string)> { (grammar.S, grammar.S) };
            HashSet<string> usedSeq = new HashSet<string>();

            while (rules.Count > 0)
            {
                // Получаем последний элемент из очереди
                var (sequence, path) = rules.Last();
                rules.RemoveAt(rules.Count - 1);

                // Если последовательность уже использовалась, продолжаем
                if (usedSeq.Contains(sequence))
                {
                    continue;
                }
                usedSeq.Add(sequence);

                bool onlyTerm = true;  // Флаг для проверки, состоит ли последовательность только из терминалов

                // Перебираем символы в текущей последовательности
                for (int i = 0; i < sequence.Length; i++)
                {
                    string symbol = sequence[i].ToString();  // Берем символ как строку
                    if (grammar.VN.Contains(symbol))  // Если это нетерминал, заменяем его
                    {
                        onlyTerm = false;
                        foreach (string elem in grammar.P[symbol])
                        {
                            string temp = sequence.Substring(0, i) + elem + sequence.Substring(i + 1);  // Применяем правило

                            // Учитываем случай с пустым производством (λ)
                            if (elem == "")
                            {
                                temp = sequence.Substring(0, i) + sequence.Substring(i + 1);
                            }

                            // Если новая цепочка не длиннее максимального предела, добавляем её в очередь
                            if (temp.Length <= rightBorder + 1)
                            {
                                // Добавляем новую цепочку вместе с шагом трансформации
                                rules.Add((temp, path + " -> " + temp));
                            }
                        }
                    }
                }

                // Если последовательность состоит только из терминалов и её длина в пределах границ, выводим результат
                if (onlyTerm && sequence.Length >= leftBorder && sequence.Length <= rightBorder)
                {
                    // Добавляем в вывод шаги, как сформировалась последовательность
                    txtOutput.AppendText(path + Environment.NewLine);

                    // Добавляем цепочку в список для выбора
                    listBoxChains.Items.Add(path);
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


        private void DrawTree(Graphics g, TreeNode node, int x, int y, int xOffset, int yOffset)
        {
            // Рисуем текущий узел
            DrawVertex(g, node.Data, x, y);

            // Рекурсивно рисуем дочерние узлы
            int childXOffset = xOffset / 2;
            for (int i = 0; i < node.Children.Count; i++)
            {
                int childX = x;
                if (node.Children.Count > 1)
                {
                    childX = x - xOffset + i * (xOffset / (node.Children.Count - 1));
                }
                int childY = y + yOffset;

                // Линия от родителя к ребенку
                g.DrawLine(Pens.Black, x, y, childX, childY);

                // Рекурсивный вызов для рисования дочерних узлов
                DrawTree(g, node.Children[i], childX, childY, xOffset / 2, yOffset);
            }
        }

        private void DrawVertex(Graphics g, string data, int x, int y)
        {
            int radius = 20;
            g.FillEllipse(Brushes.White, x - radius, y - radius, radius * 2, radius * 2);
            g.DrawEllipse(Pens.Black, x - radius, y - radius, radius * 2, radius * 2);
            g.DrawString(data, this.Font, Brushes.Black, x - radius / 2, y - radius / 2);
        }

        private TreeNode rootTree; // Для хранения корневого узла дерева

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Проверяем, есть ли дерево для отрисовки
            if (rootTree != null)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Рисуем дерево с небольшим смещением вправо
                DrawTree(g, rootTree, this.ClientSize.Width / 2 + 500, 50, 150, 75);
            }
        }


        private void BtnBuildTree_Click(object sender, EventArgs e)
        {
            if (listBoxChains.SelectedItem == null)
            {
                MessageBox.Show("Выберите цепочку для построения дерева.");
                return;
            }

            // Получаем выбранную цепочку
            string selectedChain = listBoxChains.SelectedItem.ToString();

            // Разделяем цепочку на этапы
            string[] steps = selectedChain.Split(new[] { " -> " }, StringSplitOptions.None);

            // Построение дерева на основе этапов
            rootTree = BuildTree(steps);

            // Запрос на перерисовку формы
            Invalidate();
        }


        private TreeNode BuildTree(string[] steps)
        {
            TreeNode root = new TreeNode(steps[0]);
            TreeNode current = root;

            for (int i = 1; i < steps.Length; i++)
            {
                TreeNode child = new TreeNode(steps[i]);
                current.Children.Add(child);
                current = child;
            }

            return root;
        }



    }

    public class Grammar
    {
        public List<string> VT { get; set; }  // Терминальные символы
        public List<string> VN { get; set; }  // Нетерминальные символы
        public Dictionary<string, List<string>> P { get; set; }  // Правила продукции
        public string S { get; set; }  // Начальный символ
    }

    public class TreeNode
    {
        public string Data { get; set; }
        public List<TreeNode> Children { get; set; }

        public TreeNode(string data, params TreeNode[] children)
        {
            Data = data;
            Children = new List<TreeNode>(children);
        }
    }

}