using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace Professional_GUI
{
    public partial class ExtrForm : Form
    {
        public ExtrForm()
        {
            InitializeComponent();
            reader.src = Directory.GetCurrentDirectory() + "\\Extremum.pdf";
            reader.Visible = false;
        }
        private List<string> operators =
            new List<string>(new string[] { "(", ")", "+", "-", "*", "/", "^" });
        private List<string> standart_operators =
            new List<string>(new string[] { "(", ")", "+", "-", "*", "/", "^" });
        private string arg = "x";
        List<string> operations = new List<string> { "+", "-", "*", "/", "^", "(", ")", "Compose" };
        List<string> functions = new List<string> { "sin", "cos", "exp", "tg", "ctg", "arcsin", "arccos", "arctg", "arcctg", "ln", "lg", "sh", "ch", "arcsh", "arcch" };
        /// <summary>
        /// Метод для разделения строки на функции, переменную, операторы
        /// </summary>
        private IEnumerable<string> Separate(string input)
        {
            bool normdouble = true;
            int pos = 0;
            while (pos < input.Length)
            {
                string s = string.Empty + input[pos];
                if (!standart_operators.Contains(input[pos].ToString()))
                {
                    if (Char.IsDigit(input[pos]))
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'); i++)
                        {
                            if (input[i] == ',' || input[i] == '.')
                                if (normdouble)
                                {
                                    normdouble = false;
                                    if (input[i] == '.')//Ввиду региональных настроек в double можно использовать только запятую для отделения целой и дробной частей
                                    {
                                        s += ',';
                                    }
                                    else
                                        s += input[i];
                                }
                                else
                                {
                                    //MessageBox.Show("Wrong double!");
                                    yield return "Wrong double!";
                                }
                            else
                                s += input[i];
                        }
                    else if (Char.IsLetter(input[pos]))
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsLetter(input[i]) || Char.IsDigit(input[i])); i++)
                            s += input[i];
                }
                yield return s;
                pos += s.Length;
            }
        }
        /// <summary>
        /// Определяем приоритет операций
        /// </summary>
        byte GetPriority(string s)
        {
            switch (s)
            {
                case "(":
                case ")":
                    return 0;
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "^":
                    return 3;
                default:
                    return 4;
            }
        }
        /// <summary>
        /// Преобразование строки в понимаемую машиной с использованием правил ОПН
        /// </summary>
        public List<string> ConvertToPostfixNotation(string input, ref int x1, ref int x2)
        {
            List<string> outputSeparated = new List<string>();
            Stack<string> stack = new Stack<string>();
            foreach (string c in Separate(input))
            {
                if (c.Equals(")"))
                    ++x2;
                if (c.Equals("("))
                    ++x1;
                if (c == "Wrong double!")
                {
                    outputSeparated.Add("Wrong double");
                    return outputSeparated;
                }
                double num;
                string s1 = c;
                bool isNum = Double.TryParse(s1, out num);
                if (operators.Contains(c))
                {
                    if (stack.Count > 0 && !c.Equals("("))
                    {
                        if (c.Equals(")"))
                        {
                            string s = stack.Pop();
                            while (s != "(")
                            {
                                outputSeparated.Add(s);
                                s = stack.Pop();
                            }
                        }
                        else if (GetPriority(c) > GetPriority(stack.Peek()))
                            stack.Push(c);
                        else
                        {
                            while (stack.Count > 0 && GetPriority(c) <= GetPriority(stack.Peek()))
                                outputSeparated.Add(stack.Pop());
                            stack.Push(c);
                        }
                    }
                    else
                        stack.Push(c);
                }
                else if (functions.Contains(c))
                {
                    stack.Push(c);
                    stack.Push("Compose");
                }
                else if (c == arg)
                {
                    outputSeparated.Add(c);
                }
                else if (isNum)
                {
                    outputSeparated.Add(c);
                }
                else
                {
                    //MessageBox.Show("Wrong Function");
                    outputSeparated.Add("Wrong Function");
                    return outputSeparated;
                }
            }
            if (stack.Count > 0)
                foreach (string c in stack)
                    outputSeparated.Add(c);

            return outputSeparated;
        }
        /// <summary>
        /// Проверка на константу
        /// </summary>
        public static bool ConstIsIt(String func)
        {
            try
            {
                Convert.ToDouble(func);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Проверка операции возведения в степень в случае x^[число] для красивого вывода
        /// </summary>
        public static bool MonomeIsIt(String func)
        {
            if (func.Length > 2 && func.Substring(0, 2) == "x^")
            {
                try
                {
                    Convert.ToDouble(func.Substring(2));
                    return true;
                }
                catch (Exception) { }
            }

            return false;
        }
        /// <summary>
        /// Аналитическая строковая замена производной
        /// </summary>
        public static string Diff(String func)
        {
            String result = "";
            if (ConstIsIt(func))
            {
                return "0";
            }
            else if (func == "x")
            {
                result = "1";
            }
            else if (MonomeIsIt(func))
            {
                Double power = Convert.ToDouble(func.Substring(2));
                return power.ToString() + "*x^" + (power - 1).ToString();
            }
            else if (func == "sin")
            {
                result = "cos";
            }
            else if (func == "cos")
            {
                result = "-sin";
            }
            else if (func == "exp")
            {
                result = "exp";
            }
            else if (func == "ln")
            {
                result = "1/x";
            }
            else if (func == "lg")
            {
                result = "1/(x*ln(10))";
            }
            else if (func == "tg")
            {
                result = "1/cos()^2";
            }
            else if (func == "ctg")
            {
                result = "-1/sin()^2";
            }
            //arcsin(f(x))' = f(x)' / sqrt(1 - f(x) ^ 2);
            else if (func == "arcsin")
            {
                result = "1/sqrt(1-^2)^0.5";
            }
            //arccos(f(x))' = -f(x)' / sqrt(1 - f(x) ^ 2);

            else if (func == "arccos")
            {
                result = "(-1)/sqrt(1-^2)^0.5";
            }
            //arctan(f(x))' = f(x)' / (1 + f(x) ^ 2);

            else if (func == "arctg")
            {
                result = "1/sqrt(1+^2)";
            }
            //arccot(f(x))' = -f(x)' / (1 + f(x) ^ 2);
            else if (func == "arcctg")
            {
                result = "(-1)/sqrt(1+^2)";
            }
            else if (func == "ch")
            {
                result = "sh";
            }
            else if (func == "sh")
            {
                result = "ch";
            }
            else if (func == "arcsh")
            {
                result = "1/(^2+1)^0.5";
            }
            else if (func == "arcch")
            {
                result = "1/(^2-1)^0.5";
            }
            return result;

        }
        /// <summary>
        /// Взятие готовой производной из стека, если таковая имеется
        /// </summary>
        public static string Diff(String func, Dictionary<string, string> DiffsList)
        {
            String dfunc = Diff(func);
            if (dfunc == "")
            {
                foreach (KeyValuePair<string, string> pair in DiffsList)
                {
                    if (pair.Key == func)
                    {
                        dfunc = pair.Value;
                    }
                }
            }

            return dfunc;
        }
        /// <summary>
        /// Красивый вывод произведения
        /// </summary>
        public static string SimplifyMult(string func1, string func2)
        {

            String result = "(" + func1 + ")*(" + func2 + ")";
            if (func1 == "0" || func2 == "0")
            {
                result = "0";
            }
            else if (func1 == "1")
            {
                result = func2;
            }
            else if (func2 == "1")
            {
                result = func1;
            }
            else if (ConstIsIt(func1))
            {
                result = func1 + "*(" + func2 + ")";
            }
            else if (ConstIsIt(func2))
            {
                result = func2 + "*(" + func1 + ")";
            }
            //else if (Constant.IsIt(func2))



            return result;
        }
        /// <summary>
        /// Красивый вывод суммы
        /// </summary>
        public static string SimplifyAdd(string func1, string func2, bool isAdd)
        {
            String result = "";
            if (func2 == "0")
            {
                result = func1;
            }
            else if (func1 == "0")
            {
                result = (isAdd) ? func2 : "-" + func2;
            }
            else
            {
                result = (isAdd) ?
                    func1 + "+" + func2 :
                    func1 + "-" + func2;
            }

            return result;
        }

        /// <summary>
        /// Композиции и обработка аналитического диффиренцирования
        /// </summary>
        public static String Diff(string func1, string dfunc1, string func2, string dfunc2, string oper)
        {
            String result = "";
            if (oper == "+")
            {
                result = SimplifyAdd(dfunc1, dfunc2, true);
            }
            else if (oper == "-")
            {
                result = SimplifyAdd(dfunc1, dfunc2, false);
            }
            else if (oper == "*")
            {
                String result1 = SimplifyMult(func1, dfunc2);
                String result2 = SimplifyMult(func2, dfunc1);
                result = SimplifyAdd(result1, result2, true);
            }
            else if (oper == "/")
            {
                result = "(" + SimplifyMult(func1, dfunc2) + "-" + SimplifyMult(func2, dfunc1) + ")/((" + func2 + ")^2)";
            }
            else if (oper == "^" && func1 == "x" && ConstIsIt(func2))
            {

                result = Diff(func1 + "^" + func2);
            }
            else if (oper == "^" && ConstIsIt(func2))
            {
                Double power = Convert.ToDouble(func2);
                --power;
                if (power == 1)
                {
                    result = SimplifyMult(func2, func1);
                    result = SimplifyMult(result, dfunc1);
                }
                else
                {
                    result = SimplifyMult(func2, func1);
                    result = SimplifyMult("(" + result + "^" + power + ")", dfunc1);
                }
            }
            else if (oper == "^" && !ConstIsIt(func2))
            {
                String tmp1, tmp2;
                tmp1 = SimplifyMult(dfunc1, func2);
                tmp1 = tmp1 + "/" + func1 + "+";
                tmp2 = SimplifyMult(dfunc2, "ln(" + func1 + ")");
                result = SimplifyMult(func1 + "^" + func2, tmp1 + tmp2);
            }
            //1::(f(x) ^ g(x))' = f(x) ^ g(x) * (f(x)' * g(x) / f(x) + g(x)' * ln(f(x))); Итого взят именнно этот метод
            //2::(f(x) ^ g(x))' = f(x) ^ g(x) * ln(f(x)) * g(x)' + g(x) * f(x) ^ (g(x) - 1) * f(x)'
            else if (oper == "Compose" && dfunc1 == "1/x")
            {
                if (dfunc2 == "0")
                {
                    result = "0";
                }
                else
                    result = "(" + dfunc2 + ")/(" + func2 + ")";
            }
            else if (oper == "Compose" && dfunc1 == "1/(x*ln(10))")
            {
                if (dfunc2 == "0")
                {
                    result = "0";
                }
                else
                    result = "(" + dfunc2 + ")/((" + func2 + ")*ln(10))";
            }
            else if (oper == "Compose" && dfunc1 == "1/cos()^2")//tg
            {
                result = SimplifyMult(dfunc2, "1/cos(" + func2 + ")^2");
            }
            else if (oper == "Compose" && dfunc1 == "-1/sin()^2")//ctg
            {
                result = SimplifyMult(dfunc2, "(-1)/sin(" + func2 + ")^2");
            }
            else if (oper == "Compose" && dfunc1 == "1/sqrt(1-^2)^0.5")//arcsin
            {
                result = SimplifyMult(dfunc2, "1/(1-" + func2 + "^2)^0.5");
            }
            else if (oper == "Compose" && dfunc1 == "(-1)/sqrt(1-^2)^0.5")//arccos
            {
                result = SimplifyMult(dfunc2, "(-1)/(1-(" + func2 + ")^2)^0.5");
            }
            else if (oper == "Compose" && dfunc1 == "1/sqrt(1+^2)")//arctg
            {
                result = SimplifyMult(dfunc2, "1/(1+(" + func2 + ")^2)");
            }
            else if (oper == "Compose" && dfunc1 == "(-1)/sqrt(1+^2)")//arctg
            {
                result = SimplifyMult(dfunc2, "(-1)/(1+(" + func2 + ")^2)");
            }
            else if (oper == "Compose" && dfunc1 == "1/(^2+1)^0.5")//arcsh
            {
                result = SimplifyMult(dfunc2, "1/()" + func2 + ")+1)^0.5");
            }
            else if (oper == "Compose" && dfunc1 == "1/(^2-1)^0.5")//arcch
            {
                result = SimplifyMult(dfunc2, "1/((" + func2 + ")-1)^0.5");
            }
            else if (oper == "Compose")
            {
                result = SimplifyMult(dfunc1 + "(" + func2 + ")", dfunc2);
            }

            return result;
        }
        /// <summary>
        /// Метод, реализующий нахождение значения функции в точке, сперва реализующий подстановку числа вместо переменной x
        /// </summary>
        public static double StringFunctionToDouble(double x, string s)
        {
            string specifier = "G";
            if (s == "x")
                s = s.Replace("x", "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")");
            if (s[0] == '-')
            {
                s = s.Remove(0, 1);
                s = "(-1)*" + s;
            }
            s = s.Replace("x)", x.ToString(specifier, CultureInfo.InvariantCulture) + ")");
            s = s.Replace("(x", "(" + x.ToString(specifier, CultureInfo.InvariantCulture));
            s = s.Replace("+x", "+" + "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")");
            s = s.Replace("^x", "^" + "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")");
            s = s.Replace("-x", "-" + "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")");
            s = s.Replace("*x", "*" + "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")");
            s = s.Replace("/x", "/" + "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")");

            s = s.Replace("x+", "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")" + "+");
            s = s.Replace("x^", "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")" + "^");
            s = s.Replace("x-", "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")" + "-");
            s = s.Replace("x*", "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")" + "*");
            s = s.Replace("x/", "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")" + "/");
            s = s.Replace("(x)", "(" + x.ToString(specifier, CultureInfo.InvariantCulture) + ")");
            s = s.Replace("π", Math.PI.ToString(specifier, CultureInfo.InvariantCulture));
            var v = new CalcScript().Evaluate(s);
            return v;
        }
        /// <summary>
        /// Метод, реализующий аналитическое диффиренцирование с использованием правил ОПН и алгоритм сортировочной станции
        /// </summary>
        string Differ( string func)
        {
            bool isonlyminus = false, isonlyplus = false;
            if (func.Contains("*(-"))
            {
                func = func.Replace("*(-", "*(");
                func = "(-1)*" + func;
            }
            if (func.Contains("((-"))
            {
                func = func.Replace("((-", "((");
                func = "(-1)*" + func;
            }
            if (func.Contains("(-("))
            {
                func = func.Replace("(-(", "((");
                func = "(-1)*" + func;
            }
            if (func.Contains("(-"))
            {
                func = func.Replace("(-", "(0-");
            }
            if (func == "-")
                isonlyminus = true;
            if (func[0] == '-')
            {
                func = func.Remove(0, 1);
                func = "(-1)*" + func;
            }
            if (func == "+")
            {
                isonlyplus = true;
            }
            if (func[0] == '+')
            {
                func = func.Remove(0, 1);
            }
            int x1 = 0, x2 = 0; //Number of opening and closing brackets
            List<string> arguments = ConvertToPostfixNotation(func, ref x1, ref x2);

            Dictionary<string, string> DiffsList = new Dictionary<string, string>();

            //Calculating f'
            String diff = "";
            if (x1 != x2)
            {
                //MessageBox.Show("An unequal number of parentheses is specified");
                diff = "Ошибка. Указано неравное количество скобок";
            }
            else if (arguments.Contains("Wrong double"))
            {
                diff = "Ошибка. Введено неверное число";
            }
            else if (arguments.Contains("Wrong Function"))
            {
                diff = "Ошибка. Неправильная функция";
            }
            else if (arguments.Count == 1 || isonlyminus || isonlyplus)
            {
                if (isonlyminus || isonlyplus)
                {
                    diff = "Что вы этим хотели сказать?";
                }
                else if (ConstIsIt(arguments[0]))
                {
                    diff = "0";
                }
                else if (arguments[0] == "x")
                {
                    diff = "1";
                }
                else
                    diff = "Что вы этим хотели сказать?";
            }
            /*else if (arguments.Count == 2 )
            {

                diff = arguments[1] + "1";
                
            }*/
            else
            {
                while (arguments.Count > 1)
                {
                    String firstOper = "";
                    int firstOperIndex = arguments.Count;
                    foreach (String str in operations)
                    {
                        if (arguments.IndexOf(str) > 0 && arguments.IndexOf(str) < firstOperIndex)
                        {
                            firstOperIndex = arguments.IndexOf(str);
                            firstOper = str;
                        }
                    }

                    String f1 = "", f2 = "", df1 = "", df2 = "", oper = "", expression = "";

                    if (firstOper == "Compose")
                    {
                        //arguments.RemoveAt(firstOperIndex);
                        int ComposeIndex = arguments.LastIndexOf("Compose", firstOperIndex);
                        if (ComposeIndex > 0)
                        {
                            f1 = arguments[ComposeIndex + 1];
                            df1 = Diff(f1, DiffsList);
                            f2 = arguments[ComposeIndex - 1];
                            df2 = Diff(f2, DiffsList);
                            oper = "Compose";
                            expression = f1 + "(" + f2 + ")";
                            diff = Diff(f1, df1, f2, df2, oper);

                            arguments.RemoveAt(ComposeIndex + 1);
                            arguments.RemoveAt(ComposeIndex);
                            arguments[ComposeIndex - 1] = expression;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (firstOperIndex == 1)
                        {
                            diff = arguments[firstOperIndex] + "1";
                            arguments.RemoveAt(firstOperIndex);
                            arguments[firstOperIndex - 1] = diff;
                        }
                        else
                        {
                            f1 = arguments[firstOperIndex - 2];
                            df1 = Diff(f1, DiffsList);
                            f2 = arguments[firstOperIndex - 1];
                            df2 = Diff(f2, DiffsList);
                            oper = arguments[firstOperIndex];
                            expression = f1 + oper + f2;
                            diff = Diff(f1, df1, f2, df2, oper);

                            arguments.RemoveAt(firstOperIndex);
                            arguments.RemoveAt(firstOperIndex - 1);
                            arguments[firstOperIndex - 2] = expression;
                        }
                    }

                    //ResultTextBox.Text += Environment.NewLine + expression;


                    if (!DiffsList.ContainsKey(expression))
                    {
                        DiffsList.Add(expression, diff);
                    }
                }
            }
            return(diff);
        }
        /// <summary>
        /// Нахождение локального экстремума производится по следующему алгоритму:
        /// 1) Находится производная функции
        /// 2) Ищем нули производной (методом дихотомии)
        /// 3) Проверяем знак второй производной в нулях первой производной:
        /// Если > 0, то это точка локального минимума, в противном максимума.
        /// Если у производной на заданном интервале нет нулей, локальными экстремумами являются границы интервала
        /// </summary>
        private void Calculate_Click(object sender, EventArgs e)
        {
            string res;
            if (FunctionTextBox.Text == "" || textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Вы не ввели часть требуемых данных", "Ошибка");
                res = "Input error";
                goto to_end;
            }
            string func = FunctionTextBox.Text;
            if (func.Contains("arccos") || func.Contains("arcsin") || func.Contains("acos") || func.Contains("asin") || func.Contains("arctg") || func.Contains("arcctg") || func.Contains("arcsh") || func.Contains("arcch") || func.Contains("sinh") || func.Contains("cosh") || func.Contains("ch") || func.Contains("sh"))
            {
                MessageBox.Show("Используйте только те функции, которые имеются на панели ввода!", "Ошибка");
                res = "Input error";
                goto to_end;
            }
            textBox1.Text = textBox1.Text.Replace(".", ",");
            textBox2.Text = textBox2.Text.Replace(".", ",");
            string specifier = "G";
            textBox2.Text = textBox2.Text.Replace("π", Math.PI.ToString(specifier, CultureInfo.InvariantCulture));
            textBox2.Text = textBox2.Text.Replace("pi", Math.PI.ToString(specifier, CultureInfo.InvariantCulture));
            textBox2.Text = textBox2.Text.Replace("Pi", Math.PI.ToString(specifier, CultureInfo.InvariantCulture));
            textBox1.Text = textBox1.Text.Replace("π", Math.PI.ToString(specifier, CultureInfo.InvariantCulture));
            textBox1.Text = textBox1.Text.Replace("pi", Math.PI.ToString(specifier, CultureInfo.InvariantCulture));
            textBox1.Text = textBox1.Text.Replace("Pi", Math.PI.ToString(specifier, CultureInfo.InvariantCulture));
            double a, b;
            try
            {
                a = double.Parse(textBox1.Text);
                b = double.Parse(textBox2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Введите корректные данные!");
                res = "Input error";
                goto to_end;
            }
            if( a >= b)
            {
                MessageBox.Show("Введите корректный интервал!");
                res = "Input error";
                goto to_end;
            }
            this.ChartExtremum.Series[0].Points.Clear();
            for (double z = a; z <= b; z += 0.01)
            {
                double tmp = StringFunctionToDouble(z, func);
                if (tmp == -99999999)
                    break;
                this.ChartExtremum.Series[0].Points.AddXY(z, tmp);
            }
            string diff = Differ(func);
            if (diff == "Ошибка. Указано неравное количество скобок")
            {
                res = diff;
                goto to_end;
            }
            else if (diff == "Ошибка. Введено неверное число")
             {
                res = diff;
                goto to_end;
            }
            else if (diff == "Ошибка. Неправильная функция")
             {
                res = diff;
                goto to_end;
            }
            else if (diff == "Что вы этим хотели сказать?")
             {
                res = diff;
                goto to_end;
            }
    double epsilon = 0.000001;
            
            

            while (b - a > epsilon) //МЕТОД ДИХОТОМИИ ДЛЯ ПРОИЗВОДНОЙ
            {
                double c = (a + b) / 2;
                double tmp1 = StringFunctionToDouble(b, diff), tmp2 = StringFunctionToDouble(c, diff);
                if (tmp1 == -99999999 || tmp2 == -99999999)
                {
                    res = "Input error";
                    goto to_end;
                }
                if (tmp1 * tmp2 <= 0)
                    a = c;
                else
                    b = c;
            }
            //найденное значение x в нуле функции
            double x = (a + b) / 2;
            string diff2 = Differ(diff);
            if(StringFunctionToDouble(x, diff2) > 0)
            {
                res = "(" + Math.Round(x, 2).ToString() + ";" + Math.Round(StringFunctionToDouble(x, func), 2).ToString() + ") - local min";
            }
            else if(StringFunctionToDouble(x, diff2) < 0)
                res = "(" + Math.Round(x, 2).ToString() + ";" + Math.Round(StringFunctionToDouble(x, func), 2).ToString() + ") - local max";
            else
                res = "No extremum";
        to_end:
            DiffTextBox.Visible = true;
            label2.Visible = true;
            DiffTextBox.Text = res;
        }
        /// <summary>
        /// Реализация интерфейса панели ввода данных
        /// </summary>
        private void X_Click(object sender, EventArgs e)
        {
            if (FunctionTextBox.Text == "")
                FunctionTextBox.Text += "x";
            else if (!operations.Contains(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1].ToString()))
            {
                FunctionTextBox.Text += "*x";
            }
            else
                FunctionTextBox.Text += "x";
        }

        private void Seven_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "7";
        }

        private void Four_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "4";
        }

        private void One_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "1";
        }

        private void Opening_parenthesis_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "(";
        }

        private void Eight_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "8";
        }

        private void Five_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "5";
        }

        private void Two_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "2";
        }

        private void Closing_parenthesis_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += ")";
        }

        private void Nine_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "9";
        }

        private void Six_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "6";
        }

        private void Three_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "3";
        }

        private void Div_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "/";
        }

        private void Mul_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "*";
        }

        private void Minus_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "-";
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "+";
        }

        private void Exponentiation_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "^";
        }

        private void Ln_Click(object sender, EventArgs e)
        {
            if(FunctionTextBox.Text =="")
            FunctionTextBox.Text += "ln(";
            else if (!operations.Contains(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1].ToString()))
            {
                FunctionTextBox.Text += "*ln(";
            }
            else
                FunctionTextBox.Text += "ln(";

        }

        private void Lg_Click(object sender, EventArgs e)
        {
            if (FunctionTextBox.Text == "")
                FunctionTextBox.Text += "lg(";
            else if (!operations.Contains(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1].ToString()))
            {
                FunctionTextBox.Text += "*lg(";
            }
            else
                FunctionTextBox.Text += "lg(";
        }

        private void Sinus_Click(object sender, EventArgs e)
        {
            if (FunctionTextBox.Text == "")
                FunctionTextBox.Text += "sin(";
            else if (!operations.Contains(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1].ToString()))
            {
                FunctionTextBox.Text += "*sin(";
            }
            else
                FunctionTextBox.Text += "sin(";
        }

        private void Cosinus_Click(object sender, EventArgs e)
        {
            if (FunctionTextBox.Text == "")
                FunctionTextBox.Text += "cos(";
            else if (!operations.Contains(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1].ToString()))
            {
                FunctionTextBox.Text += "*cos(";
            }
            else
                FunctionTextBox.Text += "cos(";
        }

        private void Tg_Click(object sender, EventArgs e)
        {
            if (FunctionTextBox.Text == "")
                FunctionTextBox.Text += "tg(";
            else if (!operations.Contains(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1].ToString()))
            {
                FunctionTextBox.Text += "*tg(";
            }
            else
                FunctionTextBox.Text += "tg(";
        }

        private void Ctg_Click(object sender, EventArgs e)
        {
            if (FunctionTextBox.Text == "")
                FunctionTextBox.Text += "ctg(";
            else if (!operations.Contains(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1].ToString()))
            {
                FunctionTextBox.Text += "*ctg(";
            }
            else
                FunctionTextBox.Text += "ctg(";
        }

       
        private void Delete_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            FunctionTextBox.Text = "";
            DiffTextBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(FunctionTextBox.Text == "")
            {

            }
            else
            {
                FunctionTextBox.Text = FunctionTextBox.Text.Substring(0, FunctionTextBox.Text.Length - 1);
            }
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            FunctionTextBox.Text += "0";
        }

        private void Point_Click(object sender, EventArgs e)
        {
            if (FunctionTextBox.Text == "")
                FunctionTextBox.Text += "";
            else if (Char.IsDigit(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1]))
            {
                FunctionTextBox.Text += ",";
            }
            else
                FunctionTextBox.Text += "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Calculate.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FunctionTextBox.Text == "")
                FunctionTextBox.Text += "π";
            else if (Char.IsDigit(FunctionTextBox.Text[FunctionTextBox.Text.Length - 1]))
            {
                FunctionTextBox.Text += "*π";
            }
            else
                FunctionTextBox.Text += "π"; 
        }
    }
}