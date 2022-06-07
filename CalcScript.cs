using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Professional_GUI
{
    public sealed class CalcScript
    {
        /// <summary>
        /// Фактически, этот класс является самым настоящим калькулятором, базой, без которой ни одно приличное вычисление не произвести
        /// Реализован с использованием правил ОПН
        /// </summary>
        public enum OpType : sbyte
        {
            /// <summary>
            /// Операнд выравнивания - открытая скоба (
            /// </summary>
            BrRnd = 0,
            /// <summary>
            /// {x+y}
            /// </summary>
            OpAdd,
            /// <summary>
            /// {x-y}
            /// </summary>
            OpSub,
            /// <summary>
            /// {-x}
            /// </summary>
            OpNeg,
            /// <summary>
            /// {x*y}
            /// </summary>
            OpMul,
            /// <summary>
            /// {x/y}
            /// </summary>
            OpDiv,
            /// <summary>
            /// {x^y}, pow(x,y)
            /// </summary>
            OpPow,
            /// <summary>
            /// argsin(x)
            /// </summary>
            FnAsin,
            /// <summary>
            /// argcos(x)
            /// </summary>
            FnAcos,
            /// <summary>
            /// argctg(x)
            /// </summary>
            FnActg,
            /// <summary>
            /// argtan(x)
            /// </summary>
            FnAtan,
            /// <summary>
            /// cos(x)
            /// </summary>
            FnCos,
            /// <summary>
            /// сosh(x)
            /// </summary>
            FnCosh,
            /// <summary>
            /// exp(x)
            /// </summary>
            FnExp,
            /// <summary>
            /// log(x)
            /// </summary>
            FnLog,
            /// <summary>
            /// log10(x)
            /// </summary>
            FnLog10,
            /// <summary>
            /// sin(x)
            /// </summary>
            FnSin,
            /// <summary>
            /// tan(x)
            /// </summary>
            FnTan,
            /// <summary>
            /// ctg(x)
            /// </summary>
            FnCtg,
            /// <summary>
            /// (x)!
            /// </summary>
            FnFct
        }

        #region[ Fields ]
        /// <summary>
        /// стек значений
        /// </summary>
        Stack<double> _stack = new Stack<double>();
        /// <summary>
        /// стек операций
        /// </summary>
        Stack<OpType> _opers = new Stack<OpType>();
        /// <summary>
        /// словарь переменных
        /// </summary>
        Dictionary<char, double> _params;
        /// <summary>
        /// Парсингуемое выражение
        /// </summary>
        string _expression;
        #endregion

        /// <summary>
        /// Создать скриптовый калькулятор
        /// </summary>
        public CalcScript()
        {
            this._params = new Dictionary<char, double>();
        }
        /// <summary>
        /// Создать скриптовый калькулятор
        /// </summary>
        /// <param name="Params">параметры</param>
        public CalcScript(Dictionary<char, double> Params)
        {
            this._params = Params;
        }

        /// <summary>
        /// get/set значение параметра
        /// </summary>
        /// <param name="paramName">имя параметра</param>
        public double this[char paramName]
        {
            get
            {
                double value;
                if (this._params.TryGetValue(paramName, out value)) return value;
                else return double.NaN;
            }
            set
            {
                if (this._params.ContainsKey(paramName)) this._params[paramName] = value;
                else this._params.Add(paramName, value);
            }
        }
        /// <summary>
        /// get/set значение параметра
        /// </summary>
        /// <param name="paramName">имя параметра</param>
        public double this[string paramName]
        {
            get
            {
                if (paramName.Length == 1) return this[paramName[0]];
                else throw new ArgumentException("Name of parameter must be one symbol, nnot more");
            }
            set
            {
                if (paramName.Length == 1) this[paramName[0]] = value;
                else throw new ArgumentException("Name of parameter must be one symbol, nnot more");
            }
        }
        // подсчет числа параметров в функции
        unsafe int _param_count(char* p)
        {
            int balance = 0;
            int count = 1;
            for (; ; p++)
                switch (*p)
                {
                    case '(': balance++; break;
                    case ')':
                        if (balance == 0) return count;
                        else
                        {
                            --balance;
                            break;
                        }
                    case ',':
                        if (balance == 0) count++;
                        break;
                    case '\0':
                        this._throw_exception(p, "balance of bracket is not correct");
                        count = -1;
                        return count;

                }
        }
        // выброс стандартизированного исключения
        unsafe void _throw_exception(char* p, string preMesage)
        {
            this._stack.Clear();
            this._opers.Clear();
            int index_of_errors = _position_in_string(_expression.Length, p);
            MessageBox.Show
                (
                    string.Concat
                    (
                    "Error of syntactic check of expression, ",
                    preMesage,
                    ". \n\rString: \t\t",
                    _expression,
                    "\n\rUncorrect symbol:\t",
                    new string(' ', index_of_errors),
                    (*p == '\0') ? "\\0" : p->ToString(),
                    "\n\rPosition in string:\t",
                    index_of_errors.ToString()
                    )
                );
        }
        // позиция символа в строке (для информации в Exception)
        unsafe int _position_in_string(int length, char* p)
        {
            for (; *p != '\0'; length--, p++) ;
            return length;
        }
        // x.e+degree для парсинга double
        double _pow10(int degree)
        {
            double Return = 1.0;
            if (degree > 0)
            {
                for (; degree > 15; degree -= 16) Return *= 10000000000000000.0;
                if (degree > 7) { Return *= 100000000.0; degree -= 8; }
                if (degree > 3) { Return *= 10000.0; degree -= 4; }
                if (degree > 1) { Return *= 100.0; degree -= 2; }
                if (degree == 1) Return *= 10.0;
                return Return;
            }
            else
            {
                degree = -degree;
                for (; degree > 15; degree -= 16) Return *= 10000000000000000.0;
                if (degree > 7) { Return *= 100000000.0; degree -= 8; }
                if (degree > 3) { Return *= 10000.0; degree -= 4; }
                if (degree > 1) { Return *= 100.0; degree -= 2; }
                if (degree == 1) Return *= 10.0;
                return 1.0 / Return;
            }
        }

        // пропесс обработки операций
        void _process(OpType op)
        {
            //Console.WriteLine(op +" ["+_stack.Count+"]");
            double arg1, arg2;
            switch (op)
            {
                case OpType.OpAdd:
                    arg2 = _stack.Pop();
                    arg1 = _stack.Pop();
                    _stack.Push(arg1 + arg2);
                    break;
                case OpType.OpSub:
                    arg2 = _stack.Pop();
                    arg1 = _stack.Pop();
                    _stack.Push(arg1 - arg2);
                    break;
                case OpType.OpNeg:
                    _stack.Push(-_stack.Pop());
                    break;
                case OpType.OpMul:
                    arg2 = _stack.Pop();
                    arg1 = _stack.Pop();
                    _stack.Push(arg1 * arg2);
                    break;
                case OpType.OpDiv:
                    arg2 = _stack.Pop();
                    arg1 = _stack.Pop();
                    _stack.Push(arg1 / arg2);
                    break;
                case OpType.OpPow:
                    arg2 = _stack.Pop();
                    arg1 = _stack.Pop();
                    _stack.Push(System.Math.Pow(arg1, arg2));
                    break;
                case OpType.FnAcos:
                    _stack.Push(System.Math.Acos(_stack.Pop()));
                    break;
                case OpType.FnAsin:
                    _stack.Push(System.Math.Asin(_stack.Pop()));
                    break;
                case OpType.FnAtan:
                    _stack.Push(System.Math.Atan(_stack.Pop()));
                    break;
                case OpType.FnCos:
                    _stack.Push(System.Math.Cos(_stack.Pop()));
                    break;
                case OpType.FnCosh:
                    _stack.Push(System.Math.Cosh(_stack.Pop()));
                    break;
                case OpType.FnExp:
                    _stack.Push(System.Math.Exp(_stack.Pop()));
                    break;
                case OpType.FnLog:
                    _stack.Push(System.Math.Log(_stack.Pop()));
                    break;
                case OpType.FnLog10:
                    _stack.Push(System.Math.Log10(_stack.Pop()));
                    break;
                case OpType.FnSin:
                    _stack.Push(System.Math.Sin(_stack.Pop()));
                    break;
                case OpType.FnTan:
                    _stack.Push(System.Math.Tan(_stack.Pop()));
                    break;
                case OpType.FnCtg:
                    _stack.Push(1.0 / System.Math.Tan(_stack.Pop()));
                    break;
                case OpType.FnFct:
                    int y = (int)_stack.Pop();
                    if (y == 0)
                        _stack.Push(1);
                    else
                        _stack.Push(Enumerable.Range(1, y).Aggregate((p, x) => p * x));
                    break;
                case OpType.FnActg:
                    _stack.Push(Math.PI / 2 - Math.Atan(_stack.Pop()));
                    break;
                default: throw new NotSupportedException(op.ToString());
            }
        }
        // вставка операций в стек согласно приоритету
        void _op_push(OpType op)
        {
            while (_opers.Count != 0 && (sbyte)_opers.Peek() >= (sbyte)op)
                _process(_opers.Pop());
            _opers.Push(op);
        }

        /// <summary>
        /// Вычислить значение выражения
        /// </summary>
        /// <param name="expression">выражение</param>
        /// <returns>результат</returns>
        unsafe public double Evaluate(string expression)
        {
            this._expression = expression;
            fixed (char* pin = expression)
                return _parse_body(pin);
        }
        /// <summary>
        /// Перевычислить значение последнего выражения
        /// </summary>
        /// <returns>значение</returns>
        unsafe public double Evaluate()
        {
            fixed (char* pin = this._expression)
                return _parse_body(pin);
        }

        // Разбор выражения слева направо
        unsafe double _parse_body(char* lpwcstr)
        {
            int balance = 0;
            char* p = lpwcstr;
        to_after_bropen_or_operator:
            switch (*p)
            {
                case '-': _opers.Push(OpType.OpNeg); p++; goto to_after_bropen_or_operator_faza_2;
                case '+': p++; goto to_after_bropen_or_operator_faza_2;
                case '(': balance++; p++; _opers.Push(OpType.BrRnd); goto to_after_bropen_or_operator;
                case ')':
                    Console.WriteLine("F1");
                    goto to_exception;
                case ' ':
                case '\t': p++; goto to_after_bropen_or_operator;
                default: break;
            }
        to_after_bropen_or_operator_faza_2:
            switch (*p)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case ',':
                case '.': _stack.Push(_parse_const(ref p)); goto to_after_value_or_brclose;
                case 'E':
                case 'e': _stack.Push(System.Math.E); p++; goto to_after_value_or_brclose;
                case ' ':
                case '\t': p++; goto to_after_bropen_or_operator_faza_2;
                default:
                    if (Char.IsLetter(*p))
                    {
                        if (Char.IsLetter(*(p + 1)))
                        {
                            int k = _parse_func(ref p);
                            if (k == -1)
                            {
                                _stack.Push(this._params[*p]);
                                p++;
                                _op_push(OpType.OpMul);
                                goto to_after_bropen_or_operator_faza_2;
                            }
                            else if (k == -2)
                            {
                                goto to_exception;
                            }
                            else
                            {
                                balance++;
                                p++;
                                _opers.Push(OpType.BrRnd);
                                goto to_after_bropen_or_operator;
                            }
                        }
                        else
                        {
                            goto to_exception;
                        }
                    }
                    else goto to_exception;
            }
        to_after_value_or_brclose:
            switch (*p)
            {
                case '+': _op_push(OpType.OpAdd); p++; goto to_after_bropen_or_operator;
                case '-': _op_push(OpType.OpSub); p++; goto to_after_bropen_or_operator;
                case '*': _op_push(OpType.OpMul); p++; goto to_after_bropen_or_operator;
                case '/': _op_push(OpType.OpDiv); p++; goto to_after_bropen_or_operator;
                case '^': _op_push(OpType.OpPow); p++; goto to_after_bropen_or_operator;
                //case ',': while (_opers.Peek() != OpType.BrRnd) _process(_opers.Pop()); p++; goto to_after_bropen_or_operator;
                case '(': _op_push(OpType.OpMul); goto to_after_bropen_or_operator;
                case ')':
                    if (--balance < 0)
                    {
                        Console.WriteLine("F3");
                        goto to_exception;
                    }
                    else
                    {
                        while (_opers.Peek() != OpType.BrRnd) _process(_opers.Pop());
                        _opers.Pop();
                        p++;
                        goto to_after_value_or_brclose;
                    }
                case ':':
                case '\0':
                    if (balance == 0) goto to_end_method;
                    else
                    {
                        Console.WriteLine("F4");
                        goto to_exception;
                    }
                case ' ':
                case '\t': p++; goto to_after_value_or_brclose;
                default:
                    if (Char.IsLetter(*p))
                    {
                        _op_push(OpType.OpMul);
                        goto to_after_bropen_or_operator;
                    }
                    else if (Char.IsDigit(*p) && !Char.IsLetter(*(p - 1)))
                    {
                        _op_push(OpType.OpMul);
                        goto to_after_bropen_or_operator;
                    }
                    goto to_exception;
            }
        to_exception:
            int index_of_errors = _position_in_string(_expression.Length, p);
            //throw new FormatException
            MessageBox.Show
                (
            string.Concat
            (
            "Error of syntactic check of expression. \n\rString: \t\t",
            _expression,
            "\n\rUncorrect symbol:\t",
            new string(' ', index_of_errors),
            (*p == '\0') ? "\\0" : p->ToString(),
            "\n\rPosition in string:\t",
            index_of_errors.ToString()
            )
            );
            return -99999999;
        to_end_method:
            //Console.WriteLine("End");
            while (_opers.Count != 0)
                _process(_opers.Pop());
            return _stack.Pop();
        }
        // Парсинг константы
        unsafe double _parse_const(ref char* lpwcstr)
        {
            double value = 0;
            int degree = 0;
            bool degree_sign = true;

            char* p = lpwcstr;
            for (; ; ) switch (*p)
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9': value = value * 10 + (*p - 48); p++; break;
                    case '.':
                    case ','://///////////////////////////////////////////////////////////
                        p++;
                        #region [.]
                        for (double mlt = 0.1; ; mlt *= 0.1) switch (*p)
                            {
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9': value = value + (*p - 48) * mlt; p++; break;
                                case 'E':
                                case 'e': goto to_E_region;
                                default: goto to_end_method;
                            }
                    #endregion
                    case 'E':
                    case 'e':
                    #region[E]
                    to_E_region:
                        switch (*++p)
                        {
                            case '+':
                            case '-': degree_sign = false; p++; break;
                            default: break;
                        }
                        switch (*p)
                        {
                            case '0':
                            case '1':
                            case '2':
                            case '3':
                            case '4':
                            case '5':
                            case '6':
                            case '7':
                            case '8':
                            case '9': degree = *p - 48; p++; break;
                            default:
                                switch (*--p)
                                {
                                    case '+':
                                    case '-': p--; goto to_end_method;
                                    default: goto to_end_method;
                                }
                        }
                        for (; ; )
                            switch (*p)
                            {
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9': degree = degree * 10 + (*p - 48); p++; break;
                                default: goto to_end_method;
                            }
                    #endregion
                    default: goto to_end_method;
                }

            to_end_method:
            lpwcstr = p;
            if (degree != 0)
            {
                if (degree_sign) value = value * _pow10(degree);
                else value = value * _pow10(-degree);
            }
            return value;
        }
        // Побуквенный парсинг функций
        unsafe sbyte _parse_func(ref char* lpwcstr)
        {
            char* p = lpwcstr;
            switch (*p)
            {
                case 'A':
                case 'a':
                to_after_A:
                    switch (*++p)
                    {
                        case 'C':
                        case 'c':
                            if (*++p == 'o')
                            {
                                if (*++p == 's' && *++p == '(')
                                {
                                    if (_param_count(p + 1) == 1)
                                    {
                                        _opers.Push(OpType.FnAcos);
                                        goto to_end_method;
                                    }
                                    else
                                    {
                                        _throw_exception(p, "function Acos(x) must have only one parameter");
                                        goto to_mega_exception;
                                    }
                                }
                                else goto to_mega_exception;
                            }
                            else if (*p == 't')
                                if (*++p == 'g' && *++p == '(')
                                {
                                    if (_param_count(p + 1) == 1)
                                    {
                                        _opers.Push(OpType.FnActg);
                                        goto to_end_method;
                                    }
                                    else
                                    {
                                        _throw_exception(p, "function Actg(x) must have only one parameter");
                                        goto to_mega_exception;
                                    }

                                }
                                else goto to_mega_exception;
                            else goto to_mega_exception;
                        case 'S':
                        case 's':
                            if (*++p == 'i' && *++p == 'n' && *++p == '(')
                            {
                                if (_param_count(p + 1) == 1)
                                {
                                    _opers.Push(OpType.FnAsin);
                                    goto to_end_method;
                                }
                                else
                                {
                                    _throw_exception(p, "function Asin(x) must have only one parameter");
                                    goto to_mega_exception;
                                }
                            }
                            else goto to_mega_exception;
                        case 'T':
                        case 't':
                            if (*++p == 'g' && *++p == '(')
                            {
                                if (_param_count(p + 1) == 1)
                                {
                                    _opers.Push(OpType.FnAtan);
                                    goto to_end_method;
                                }
                                else
                                {
                                    _throw_exception(p, "function Atan(x) must have only one parameter");
                                    goto to_mega_exception;
                                }
                            }
                            else goto to_mega_exception;
                        case 'r':
                            if (*++p == 'g') goto to_after_A;
                            else goto to_exception;
                        default:  goto to_mega_exception;
                    }
                case 'C':
                case 'c':
                    if (*++p == 'o')
                    {
                        if (*++p == 's' && *++p == '(')
                        {
                            if (_param_count(p + 1) == 1)
                            {
                                _opers.Push(OpType.FnCos);
                                goto to_end_method;
                            }
                            else
                            {
                                _throw_exception(p, "function Cos(x) must have only one parameter");
                                goto to_mega_exception;
                            }
                        }
                        else if (*p == 'h' && *++p == '(')
                        {
                            if (_param_count(p + 1) == 1)
                            {
                                _opers.Push(OpType.FnCosh);
                                goto to_end_method;
                            }
                            else
                            {
                                _throw_exception(p, "function Cosh(x) must have only one parameter");
                                goto to_mega_exception;
                            }
                        }
                        else goto to_mega_exception;
                    }
                    else if (*p == 't')
                    {
                        if (*++p == 'g' && *++p == '(')
                        {
                            if (_param_count(p + 1) == 1)
                            {
                                _opers.Push(OpType.FnCtg);
                                goto to_end_method;
                            }
                            else
                            {
                                _throw_exception(p, "function Ctg(x) must have only one parameter");
                                goto to_mega_exception;
                            }
                        }
                        else goto to_mega_exception;
                    }
                    else goto to_mega_exception;

                case 'E':
                case 'e':
                    if (*++p == 'x' && *++p == 'p' && *++p == '(')
                    {
                        if (_param_count(p + 1) == 1)
                        {
                            _opers.Push(OpType.FnExp);
                            goto to_end_method;
                        }
                        else
                        {
                            _throw_exception(p, "function Exp(x) must have only one parameter");
                            goto to_mega_exception;
                        }
                    }
                    else goto to_mega_exception;
                case 'F':
                case 'f':
                    if (*++p == 'a' && *++p == 'c' && *++p == 't' && *++p == '(')
                    {
                        if (_param_count(p + 1) == 1)
                        {
                            _opers.Push(OpType.FnFct);
                            goto to_end_method;
                        }
                        else
                        {
                            _throw_exception(p, "function (x)! must have only one parameter");
                            goto to_mega_exception;
                        }
                    }
                    else goto to_mega_exception;
                case 'L':
                case 'l':
                    ++p;
                    if (*p == 'g')
                        if (*++p == '(')
                        {
                            if (_param_count(p + 1) == 1)
                            {
                                _opers.Push(OpType.FnLog);
                                goto to_end_method;

                            }
                            else
                            {
                                _throw_exception(p, "function Lg(x) must have only one parameter");
                                goto to_mega_exception;
                            }
                        }
                        else goto to_mega_exception;
                    else if (*p == 'n')
                        if (*++p == '(')
                        {
                            if (_param_count(p + 1) == 1)
                            {
                                _opers.Push(OpType.FnLog10);
                                goto to_end_method;
                            }
                            else
                            {
                                _throw_exception(p, "function Ln(x) must have only one parameter");
                                goto to_mega_exception;
                            }
                        }
                        else goto to_mega_exception;
                    else goto to_exception;
                case 'S':
                case 's':
                    switch (*++p)
                    {
                        case 'i':
                            if (*++p == 'n' && *++p == '(' || (*p == 'h' && *++p == '('))
                                if (_param_count(p + 1) == 1)
                                {
                                    _opers.Push(OpType.FnSin);
                                    goto to_end_method;
                                }
                                else
                                {
                                    _throw_exception(p, "function Sin(x) must have only one parameter");
                                    goto to_mega_exception;
                                }
                            else goto to_mega_exception;
                        default: goto to_exception;
                    }
                case 'T':
                case 't':
                    if (*++p == 'g' && *++p == '(') if (_param_count(p + 1) == 1)
                        {
                            _opers.Push(OpType.FnTan);
                            goto to_end_method;
                        }
                        else
                        {
                            _throw_exception(p, "function Tan(x) must have only one parameter");
                            goto to_mega_exception;
                        }
                    else goto to_mega_exception;
                default: goto to_mega_exception;
            }
        to_mega_exception:
            return -2;
        to_exception:
            return -1;
        to_end_method:
            lpwcstr = p;
            return 1;
        }
    }

}
