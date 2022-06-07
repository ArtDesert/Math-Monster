using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Professional_GUI
{
    internal class Algebra
    {
        /// <summary>
        /// Класс, представляющий матрицу
        /// </summary>
        public class Matrix
        {
            public int row, col;
            public double[,] arr;

            /// <summary>
            /// Создаёт матрицу заданного размера с рандомными числами
            /// </summary>
            /// <param name="row">Число строк</param>
            /// <param name="col">Число столбцов</param>
            ///
            public Matrix(int row, int col)
            {
                this.arr = new double[row, col];
                this.row = row;
                this.col = col;
                Random rand = new Random();
                for (int i = 0; i < row; ++i)
                    for (int j = 0; j < col; ++j)
                        this.arr[i, j] = rand.Next(10);
            }

            /// <summary>
            /// Создаёт матрицу и заполняет ее заданным числом
            /// </summary>
            /// <param name="row">Число строк</param>
            /// <param name="col">Число столбцов</param>
            /// <param name="data">Число для заполнения</param>
            public Matrix(int row, int col, double data)
            {
                this.arr = new double[row, col];
                this.row = row;
                this.col = col;
                for (int i = 0; i < row; ++i)
                    for (int j = 0; j < col; ++j)
                        this.arr[i, j] = data;
            }

            /// <summary>
            /// Создаёт матрицу и заполняет её значениями другой матрицы
            /// </summary>
            /// <param name="matrix">Матрица</param>
            public Matrix(Matrix matrix) // Инициализация матрицы от другой матрицы
            {
                this.row = matrix.row;
                this.col = matrix.col;
                this.arr = new double[row, col];
                for (int i = 0; i < row; ++i)
                {
                    for (int j = 0; j < col; ++j)
                        this.arr[i, j] = matrix.arr[i, j];
                }
            }
            /// <summary>
            /// Создаёт матрицу и заполняет её значениями двумерного массива
            /// </summary>
            /// <param name="arr">Двумерный массив</param>
            public Matrix(double[,] arr) //Инициализация матрицы от двумерного массива
            {
                row = arr.GetLength(0);
                col = arr.GetLength(1);
                this.arr = new double[row, col];
                for (int i = 0; i < row; ++i)
                {
                    for (int j = 0; j < col; ++j)
                        this.arr[i, j] = arr[i, j];
                }
            }

            /// <summary>
            /// Создаёт единичную матрицу указанного порядка
            /// </summary>
            /// <param name="order"></param>
            public Matrix(int order)
            {
                if (order < 1) throw new IllegalArgumentException("Порядок матрицы не может быть меньше 1");
                row = col = order;
                arr = new double[order, order];
                for (int i = 0; i < order; ++i)
                {
                    for (int j = 0; j < order; ++j)
                    {
                        if (i == j) arr[i, j] = 1;
                        else arr[i, j] = 0;
                    }
                }
            }

            /// <summary>
            /// Создаёт копию матрицы
            /// </summary>
            /// <returns></returns>
            public Matrix Copy()
            {
                return new Matrix(this);
            }

            /// <summary>
            /// Возвращает матрицу, представляющую строку с заданным индексом
            /// </summary>
            /// <param name="index">Индекс строки</param>
            /// <returns>Строка матрицы</returns>
            public Matrix GetRow(int index)
            {
                double[,] arr = new double[1, col];
                for (int i = 0; i < col; ++i) arr[0, i] = this.arr[index, i];
                return new Matrix(arr);
            }

            /// <summary>
            /// Возвращает матрицу, представляющую столбец с заданным индексом
            /// </summary>
            /// <param name="index">Индекс столбца</param>
            /// <returns>Столбец матрицы</returns>
            public Matrix GetColumn(int index)
            {
                double[,] arr = new double[row, 1];
                for (int i = 0; i < row; ++i) arr[i, 0] = this.arr[i, index];
                return new Matrix(arr);
            }

            override public String ToString()
            {
                String str = "";
                for (int i = 0; i < this.row; ++i)
                {
                    for (int j = 0; j < this.col; ++j)
                    {
                        str += this.arr[i, j] + " ";
                    }
                    str += "\n";
                }
                return str;
            }
            /// <summary>
            /// Строит матрицу, получающуюся из исходной вычёркиванием i-ой строки и j-го столбца
            /// </summary>
            /// <param name="i">Номер строки</param>
            /// <param name="j">Номер столбца</param>
            /// <returns></returns>
            /// <exception cref="MatrixException">Матрица неквадратная или параметры выходят за границы матрицы</exception>
            public Matrix PseudoMinor(int i, int j)
            {
                if (row != col) throw new MatrixException("Матрица неквадратная");
                if (i >= row || j >= col) throw new MatrixException("Нет таких индексов");
                double[,] minor = new double[row - 1, col - 1];
                for (int k = 0; k < row; ++k)
                {
                    for (int s = 0; s < col; ++s)
                    {
                        if (k == i || s == j) continue;
                        else if (k < i && s < j) minor[k, s] = arr[k, s];
                        else if (k < i && s > j) minor[k, s - 1] = arr[k, s];
                        else if (k > i && s < j) minor[k - 1, s] = arr[k, s];
                        else minor[k - 1, s - 1] = arr[k, s];
                    }
                }
                return new Matrix(minor);
            }

            /// <summary>
            /// Вычисляет определитель матрицы по определению
            /// </summary>
            /// <param name="matrix">Матрица</param>
            /// <returns>Определитель матрицы</returns>
            /// я
            public static double Det(Matrix matrix)
            {
                double sum = 0;
                if (matrix.row == 1)
                {
                    return matrix.arr[0, 0];
                }
                else for (int i = 0; i < matrix.arr.GetLength(0); ++i)
                    {
                        sum += Math.Pow(-1, i) * matrix.arr[0, i] * Det(matrix.PseudoMinor(0, i));
                    }
                return sum;
            }

            /// <summary>
            /// Вычисляет определитель матрицы алгоритмом Гаусса
            /// </summary>
            /// <param name="matrix">Матрица</param>
            /// <returns>Определитель матрицы</returns>
            public static double GaussDet(Matrix matrix)
            {
                var m = matrix.Copy();
                int swaps = m.GaussStepwise();
                double value = 1;
                for (int i = 0; i < m.row; ++i)
                    value *= m.arr[i, i];
                return Math.Pow(-1, swaps) * value;
            }

            /// <summary>
            /// Приводит матрицу к ступенчатому виду алгоритмом Гаусса
            /// </summary>
            /// <returns>Число перестановок строк</returns>
            public int GaussStepwise()
            {
                int count = this.row, swaps = 0;
                for (int k = count - 1; k > 0; --k)
                {

                    var index = count - k - 1;
                    for (int i = index + 1; i < count; ++i)
                    {
                        double coef;
                        for (var cur = i; this.arr[index, index] == 0 && cur < this.row; ++cur)
                        {
                            this.SwapRows(i - 1, cur);
                            ++swaps;
                        }
                        if (this.arr[index, index] == 0) continue;
                        coef = this.arr[i, index] / this.arr[index, index];
                        for (int j = index; j < this.col; ++j) this.arr[i, j] -= this.arr[index, j] * coef;
                    }
                }
                return swaps;
            }

            /// <summary>
            /// Вычисляет сумму двух матриц
            /// </summary>
            /// <param name="matrix1">Первая матрица</param>
            /// <param name="matrix2">Вторая матрица</param>
            /// <returns>Сумма двух матриц</returns>
            /// <exception cref="MatrixException">Матрицы разных размеров</exception>
            public static Matrix Sum(Matrix matrix1, Matrix matrix2)
            {
                if (matrix1.row != matrix2.row || matrix1.col != matrix2.col) throw new MatrixException("Матрицы разных размеров");
                double[,] arr = new double[matrix1.row, matrix1.col];
                for (int i = 0; i < matrix1.row; ++i)
                {
                    for (int j = 0; j < matrix1.col; ++j)
                        arr[i, j] = matrix1.arr[i, j] + matrix2.arr[i, j];
                }
                return new Matrix(arr);
            }
            /// <summary>
            /// Вычисляет произведение двух матриц
            /// </summary>
            /// <param name="matrix1">Первая матрица</param>
            /// <param name="matrix2">Вторая матрица</param>
            /// <returns>Произведение двух матриц</returns>
            /// <exception cref="MatrixException">Матрицы разных размеров</exception>
            public static Matrix Mult(Matrix matrix1, Matrix matrix2)
            {
                if (matrix1.col != matrix2.row) throw new MatrixException("Матрицы разных размеров");
                double[,] arr = new double[matrix1.row, matrix2.col];
                for (int i = 0; i < matrix1.row; ++i)
                {
                    for (int j = 0; j < matrix2.col; ++j)
                    {
                        for (int k = 0; k < matrix1.col; ++k)
                        {
                            arr[i, j] += matrix1.arr[i, k] * matrix2.arr[k, j];
                        }
                    }
                }
                return new Matrix(arr);
            }
            /// <summary>
            /// Вычисляет матрицу в n-ой степени
            /// </summary>
            /// <param name="n">Степень</param>
            /// <returns>Матрица в n-ой степени</returns>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public Matrix Deg(int n)
            {
                if (n < 1) throw new IllegalArgumentException("n<1");
                if (n == 1) return this;
                Matrix temp = this.Copy();
                while (n > 1)
                {
                    temp = Matrix.Mult(temp, this);
                    --n;
                }
                return temp;
            }

            /// <summary>
            /// Умножает матрицу на число
            /// </summary>
            /// <param name="scalar">Число</param>
            /// <returns>Матрица, умноженная на число</returns>
            public Matrix MultByScalar(double scalar)
            {
                Matrix matrix = this.Copy();
                for (int i = 0; i < matrix.row; ++i)
                {
                    for (int j = 0; j < matrix.col; ++j)
                    {
                        matrix.arr[i, j] *= scalar;
                    }
                }
                return matrix;
            }

            /// <summary>
            /// Вычисляет разность матриц
            /// </summary>
            /// <param name="matrix1">Первая матрица</param>
            /// <param name="matrix2">Вторая матрица</param>
            /// <returns>Разность матриц</returns>
            public static Matrix Diff(Matrix matrix1, Matrix matrix2)
            {
                return Matrix.Sum(matrix1, matrix2.MultByScalar(-1));
            }
            /// <summary>
            /// Меняет местами две строки
            /// </summary>
            /// <param name="index1">Индекс первой строки</param>
            /// <param name="index2">Индекс второй строки</param>
            public void SwapRows(int index1, int index2)
            {
                double[] temp = new double[col];
                for (int i = 0; i < col; ++i) temp[i] = this.arr[index1, i];
                for (int i = 0; i < col; ++i) this.arr[index1, i] = this.arr[index2, i];
                for (int i = 0; i < col; ++i) this.arr[index2, i] = temp[i];
            }
            /// <summary>
            /// Меняет местами два столбца
            /// </summary>
            /// <param name="index1">Индекс первого столбца</param>
            /// <param name="index2">Индекс второго столбца</param>
            public void SwapColumns(int index1, int index2)
            {
                double[] temp = new double[row];
                for (int i = 0; i < row; ++i) temp[i] = this.arr[i, index1];
                for (int i = 0; i < row; ++i) this.arr[i, index1] = this.arr[i, index2];
                for (int i = 0; i < row; ++i) this.arr[i, index2] = temp[i];
            }
            /// <summary>
            /// Транспонирует матрицу
            /// </summary>
            /// <returns>Копия транспонированной матрица</returns>
            public Matrix Transpose() //Транспонирование матрицы
            {
                var cur = this.GetRow(0);
                double[,] arr = new double[col, 1];
                for (int i = 0; i < col; ++i)
                {
                    arr[i, 0] = cur.arr[0, i];
                }
                var T = new Matrix(arr);
                for (int i = 1; i < row; ++i)
                {
                    cur = this.GetRow(i);
                    for (int j = 0; j < col; ++j)
                    {
                        arr[j, 0] = cur.arr[0, j];
                    }
                    T = Concat(T, new Matrix(arr));
                }
                return T;
            }
            /// <summary>
            /// Вычисляет матрицу из алгебраических дополнений
            /// </summary>
            /// <param name="matrix">Матрица</param>
            /// <returns>Матрица из алгебраических дополнений</returns>
            /// <exception cref="MatrixException"></exception>
            public static Matrix Attached(Matrix matrix)
            {
                double[,] arr = new double[matrix.row, matrix.col];
                if (matrix.row != matrix.col) throw new MatrixException("Матрица неквадратная");
                for (int i = 0; i < matrix.row; ++i)
                {
                    for (int j = 0; j < matrix.col; ++j)
                    {
                        arr[i, j] = Math.Pow(-1, i + j) * Det(matrix.PseudoMinor(i, j));
                    }
                }
                return new Matrix(arr);
            }
            /// <summary>
            /// Вычисляет обратную матрицу
            /// </summary>
            /// <returns>Обратная матрица</returns>
            /// <exception cref="MatrixException"></exception>
            public Matrix Inverse()  //Обратная матрица
            {
                if (row != col) throw new MatrixException("Матрица неквадратная");
                double d = Det(this);
                if (d == 0) throw new MatrixException("Матрица необратима");
                double[,] arr = new double[row, col];
                Matrix attached = Attached(this.Transpose());
                for (int i = 0; i < row; ++i)
                {
                    for (int j = 0; j < col; ++j)
                    {
                        arr[i, j] = attached.arr[i, j] / d;
                    }
                }
                return new Matrix(arr);
            }
            public void SumRowsWithScalar(int index1, int index2, double scalar) //Прибавление к первой строке второй, умноженную на число
            {
                if (index1 < 0 || index1 >= row || index2 < 0 || index2 >= row) throw new MatrixException("Некорректный индекс");
                for (int j = 0; j < col; ++j)
                {
                    arr[index1, j] += arr[index2, j] * scalar;
                }
            }

            public void SumColumnsWithScalar(int index1, int index2, double scalar)  //Прибавление к первому столбцу второго, умноженного на число
            {
                if (index1 < 0 || index1 >= col || index2 < 0 || index2 >= col) throw new MatrixException("Некорректный индекс");
                for (int i = 0; i < row; ++i)
                {
                    arr[i, index1] += arr[i, index2] * scalar;
                }
            }
            /// <summary>
            /// Строит конкатенацию матриц
            /// </summary>
            /// <param name="m1">Первая матрица</param>
            /// <param name="m2">Вторая матрица</param>
            /// <returns>Конкатенация матрица</returns>
            /// <exception cref="MatrixException"></exception>
            public static Matrix Concat(Matrix m1, Matrix m2)
            {
                if (m1.row != m2.row) throw new MatrixException("invalid size");
                double[,] arr = new double[m1.row, m1.col + m2.col];
                for (int i = 0; i < m1.row; ++i)
                {
                    for (int j = 0; j < m1.col; ++j)
                    {
                        arr[i, j] = m1.arr[i, j];
                    }
                    for (int j = m1.col; j < m1.col + m2.col; ++j)
                    {
                        arr[i, j] = m2.arr[i, j - m1.col];
                    }
                }
                return new Matrix(arr);
            }

            public static Matrix VerticalConcat(Matrix m1, Matrix m2)
            {
                if (m1.col != m2.col) throw new MatrixException("invalid size");
                double[,] arr = new double[m1.row + m2.row, m1.col];
                for (int i = 0; i < m1.col; ++i)
                {
                    for (int j = 0; j < m1.row; ++j)
                    {
                        arr[j, i] = m1.arr[j, i];
                    }
                    for (int j = m1.row; j < m1.row + m2.row; ++j)
                    {
                        arr[j, i] = m2.arr[j - m1.row, i];
                    }
                }
                return new Matrix(arr);
            }

            /// <summary>
            /// Вычисляет ранг матрицы алгоритмом Гаусса
            /// </summary>
            /// <returns>Ранг матрицы</returns>
            public int GaussRank()
            {
                var m = this.Copy();
                m.GaussStepwise();
                int k = m.col - 1;
                var last = m.GetColumn(k);
                int rank = 0;
                for (int i = 0; i < m.row; ++i)
                    if (last.arr[i, 0] != 0) ++rank;
                return rank;
            }
            /// <summary>
            /// Вычисляет угловой минор указанного порядка 
            /// </summary>
            /// <param name="order">Порядок минора(начинается с 1)</param>
            /// <returns></returns>
            public double AngularMinor(int order)
            {
                double[,] arr = new double[order, order];
                for (int i = 0; i < order; ++i)
                    for (int j = 0; j < order; ++j) arr[i, j] = this.arr[i, j];
                return Matrix.Det(new Matrix(arr));
            }
            /// <summary>
            /// Определяет, является ли матрица положительно определённой
            /// </summary>
            /// <returns></returns>
            public bool IsPositivelyDefined()
            {
                for (int i = 0; i < this.row; ++i)
                    if (this.AngularMinor(i + 1) <= 0) return false;
                return true;
            }
            /// <summary>
            /// Определяет, является ли матрица отрицательно определённой
            /// </summary>
            /// <returns></returns>
            public bool IsNegativelyDefined()
            {
                for (int i = 1; i <= this.row; i += 2)
                    if (this.AngularMinor(i) >= 0) return false;
                for (int i = 2; i <= this.row; i += 2)
                    if (this.AngularMinor(i) <= 0) return false;
                return true;
            }

            /// <summary>
            /// Решает систему линейных однородных уравнений
            /// </summary>
            /// <param name="matrix">Матрица системы</param>
            /// <returns>Матрица, столбцы которой образуют ФСР системы</returns>
            public static Matrix SystemOfLinearHomogeneousEquations(Matrix matrix)
            {
                int n = matrix.row, r = matrix.GaussRank();
                if (r == n) return new Matrix(n, 1, 0);
                var tempMatrix = matrix.Copy();
                tempMatrix.GaussStepwise();
                var sln = VerticalConcat(new Matrix(r, n - r, 0), new Matrix(n - r));
                for (int j = 0; j < n - r; ++j)
                {
                    for (int i = r - 1; i >= 0; --i)
                    {
                        sln.arr[i, j] = Mult(tempMatrix.GetRow(i), sln.GetColumn(j)).arr[0, 0] / -tempMatrix.arr[i, i];
                    }
                }
                return sln;
            }
            /// <summary>
            /// Решает систему линейных неоднородных уравнений
            /// </summary>
            /// <param name="matrix">Матрица системы</param>
            /// <param name="col">Правая часть системы</param>
            /// <returns>Матрица, столбцы которой образуют ФСР системы + частное решение</returns>
            public static Matrix SystemOfLinearInhomogeneousEquations(Matrix matrix, Matrix col)
            {
                int n = matrix.row;
                var exm = Concat(matrix, col);
                var m = matrix.Copy();
                m.GaussStepwise();
                exm.GaussStepwise();
                int r = exm.GaussRank();
                if (r != m.GaussRank()) return null;
                var sln = SystemOfLinearHomogeneousEquations(matrix);
                if (sln == null) return null;
                var prsln = new Matrix(matrix.row, 1, 0);
                for (int i = r - 1; i >= 0; --i)
                {
                    prsln.arr[i, 0] = (exm.GetColumn(matrix.col).arr[i, 0] - Mult(m.GetRow(i), prsln).arr[0, 0]) / exm.arr[i, i];
                }
                if (n != matrix.GaussRank())
                {
                    sln = Concat(sln, prsln);
                    return sln;
                }
                return prsln;
            }

            /// <summary>
            /// Раскладывает невырожденную матрицу на две квадратные матрицы L и U, где L - нижняя унитреугольная матрица, а U - верхняя треугольная
            /// </summary>
            /// <returns>Трёхмерный массив, нулевой элемент которого - матрица L, второй элемент - матрица U</returns>
            public Matrix[] LUFactorization()
            {
                if (Det(this) == 0) throw new MatrixException("LU-разложения не существует, так как матрица вырождена");
                int n = this.row;
                Matrix[] marr = new Matrix[2];
                var L = new Matrix(n);
                var U = new Matrix(n, n, 0);
                double cur;
                for (int i = 0; i < n; ++i)
                    for (int j = 0; j < n; ++j)
                    {
                        if (i <= j)
                        {
                            cur = 0;
                            for (int k = 0; k < i; ++k)
                                cur += L.arr[i, k] * U.arr[k, j];
                            U.arr[i, j] = arr[i, j] - cur;
                        }
                        else
                        {
                            cur = 0;
                            for (int k = 0; k < j; ++k)
                                cur += L.arr[i, k] * U.arr[k, j];
                            L.arr[i, j] = (arr[i, j] - cur) / U.arr[j, j];
                        }
                    }
                marr[0] = L;
                marr[1] = U;
                return marr;
            }

            public Matrix Proj(Matrix b)
            {
                return b.MultByScalar(Mult(this.Transpose(), b).arr[0, 0] / Mult(b.Transpose(), b).arr[0, 0]);
            }

            public Matrix Norm()
            {
                return this.MultByScalar(1 / Math.Sqrt(Mult(this.Transpose(), this).arr[0, 0]));
            }

            /// <summary>
            /// Раскладывает невырожденную матрицу на две квадратные матрицы Q и R, где Q - ортогональная матрица, R - верхнетреугольная матрица
            /// </summary>
            /// <returns>Трёхмерный массив, нулевой элемент которого - матрица Q, второй элемент - матрица R</returns>
            /// <exception cref="MatrixException">Выбрасывает исключение, когда матрица вырождена</exception>
            public Matrix[] QRFactorization()
            {
                if (Det(this) == 0) throw new MatrixException("QR-разложения не существует, так как матрица вырождена");
                int n = this.row;
                Matrix[] marr = new Matrix[2];
                var b0 = this.GetColumn(0);
                var Q = new Matrix(b0.Norm());
                for (int i = 1; i < col; ++i)
                {
                    var cur = this.GetColumn(i);
                    for (int j = 0; j < i; ++j)
                    {
                        cur = Diff(cur, cur.Proj(Q.GetColumn(j)));
                    }
                    Q = Concat(Q, cur.Norm());
                }
                var R = Mult(Q.Transpose(), this);
                marr[0] = Q;
                marr[1] = R;
                return marr;
            }
        }

        [Serializable]
        internal class MatrixException : Exception
        {
            public MatrixException()
            {
            }

            public MatrixException(string message) : base(message)
            {
            }

            public MatrixException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected MatrixException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        public class Vector
        {
            private double[] Coords;
            public double[] coords
            {
                get { return Coords; }
                set { Coords = value; }
            }
            private int Size;
            public int size
            {
                get { return Size; }
                set { Size = value; }
            }
            public Vector(int len)
            {
                Size = len;
                Coords = new double[len];
            }
            public Vector(params double[] cs)
            {
                Size = cs.Length;
                Coords = new double[Size];
                for (int i = 0; i < Size; ++i)
                    Coords[i] = cs[i];
            }
            public double this[int num]
            {
                get
                {
                    if ((num < Size) && (num > -1))
                        return Coords[num];
                    else
                        throw new IndexOutOfRangeException("Элемента с заданным индексом не существует");
                }
                set
                {
                    if ((num < Size) && (num > -1))
                        Coords[num] = value;
                    else
                        throw new IndexOutOfRangeException("Элемента с заданным индексом не существует");
                }
            }
            public double GetNorm()
            {
                double sum = 0;
                foreach (double c in Coords)
                    sum += Math.Pow(c, 2);

                return Math.Sqrt(sum);
            }
            public Vector Reverse()
            {
                Vector v = new Vector(Size);
                for (int i = 0; i < Size; ++i)
                    v[i] = -Coords[i];
                return v;
            }
            public void Mul(double n)
            {
                for (int i = 0; i < Size; ++i)
                    Coords[i] *= n;
            }
            public override string ToString()
            {
                string s = "{ ";
                for (int i = 0; i < Size; ++i)
                    s += Coords[i] + "  ";
                s += "}";
                return s;
            }
        }

        public class OperationsOnVectors
        {
            public static Vector Sum(Vector v1, Vector v2)
            {
                if (v1.size == v2.size)
                {
                    Vector v = new Vector(v1.size);
                    for (int i = 0; i < v1.size; ++i)
                        v[i] = v1[i] + v2[i];
                    return v;
                }
                else
                    throw new FormatException("Размерности векторов не совпадают. Действие невозможно.");
            }
            public static Vector Dif(Vector v1, Vector v2)
            {
                return Sum(v1, v2.Reverse());
            }
            public static double Scalar(Vector v1, Vector v2)
            {
                double v = 0;
                if (v1.size == v2.size)
                    for (int i = 0; i < v1.size; ++i)
                        v += v1[i] * v2[i];
                else
                    throw new FormatException("Размерности векторов не совпадают. Действие невозможно.");

                return v;
            }
            public static Vector SubVector(Vector v1, Vector v2)
            {
                if (v1.size == v2.size)
                {
                    if (v1.size == 3)
                        return new Vector((v1.coords[1] * v2.coords[2] - v1.coords[2] * v2.coords[1]),
                                            (v1.coords[2] * v2.coords[0] - v1.coords[0] * v2.coords[2]),
                                            (v1.coords[0] * v2.coords[1] - v1.coords[1] * v2.coords[0]));
                    else
                        throw new FormatException("Операция невозможна для вектороов данной размерности");
                }
                else
                    throw new FormatException("Размерности векторов не совпадают. Действие невозможно.");
            }
            public static double Mix(Vector v1, Vector v2, Vector v3)
            {
                if (v1.size == 3)
                {
                    if ((v1.size == v2.size) && (v2.size == v3.size))
                    {
                        Matrix m = new Matrix(new double[3, 3]
                        {
                        { v1.coords[0],  v1.coords[1], v1.coords[2]},
                        { v2.coords[0],  v2.coords[1], v2.coords[2]},
                        { v3.coords[0],  v3.coords[1], v3.coords[2]}
                        });
                        return Matrix.Det(m);
                    }
                    else
                        throw new FormatException("Размерности векторов не совпадают. Действие невозможно.");
                }
                else
                    throw new FormatException("Операция невозможна для вектороов данной размерности");
            }
            public static double Angle(Vector v1, Vector v2)
            {
                return Math.Acos(Math.Round(Scalar(v1, v2) / (v1.GetNorm() * v2.GetNorm()), 4)) * 180 / Math.PI;
            }
            public static double GetNorm(Vector v)
            {
                return v.GetNorm();
            }
        }

        public class Polynom
        {
            private double[] Coefs;
            public double[] coefs
            {
                get { return Coefs; }
                set { Coefs = value; }
            }
            private int Degree;
            public int degree
            {
                get { return Degree; }
                set { Degree = value; }
            }
            public Polynom(double[] coefs, int degree)
            {
                Coefs = coefs;
                Degree = degree;
            }
            //a0 * x^n + ... a(n-1) * x + an
            public static Polynom operator +(Polynom A, Polynom B)
            {
                int maxDeg = Math.Max(A.Degree, B.Degree);
                double[] M1 = new double[maxDeg + 1];
                Polynom C = new Polynom(M1, maxDeg);
                if (A.Degree > B.Degree)
                {
                    for (int i = 0; i < A.Degree - B.Degree; ++i)
                        C.Coefs[i] = A.Coefs[i];
                    for (int i = A.Degree - B.Degree; i < A.Degree + 1; ++i)
                        C.Coefs[i] = A.Coefs[i] + B.Coefs[i + B.Degree - A.Degree];
                }
                else if (A.Degree < B.Degree)
                {
                    for (int i = 0; i < B.Degree - A.Degree; ++i)
                        C.Coefs[i] = B.Coefs[i];
                    for (int i = B.Degree - A.Degree; i < B.Degree + 1; ++i)
                        C.Coefs[i] = A.Coefs[i - B.Degree + A.Degree] + B.Coefs[i];
                }
                else
                    for (int i = 0; i < A.Degree + 1; ++i)
                        C.Coefs[i] = A.Coefs[i] + B.Coefs[i];
                return C;
            }
            public static Polynom operator -(Polynom A, Polynom B)
            {
                for (int i = 0; i < B.Degree + 1; ++i)
                    B.Coefs[i] *= -1;
                return (A + B);
            }
            public static Polynom operator *(Polynom p1, Polynom p2)
            {
                int deg = p1.degree + p2.degree;
                double[] cs = new double[p1.coefs.Length + p2.coefs.Length - 1];
                for (int i = 0; i < p1.coefs.Length; ++i)
                    for (int j = 0; j < p2.coefs.Length; ++j)
                        cs[i + j] += p1.coefs[i] * p2.coefs[j];
                return new Polynom(cs, deg);
            }
            public static Polynom operator *(Polynom p1, double n)
            {
                double[] cs = new double[p1.degree + 1];
                for (int i = 0; i < p1.coefs.Length; ++i)
                    cs[i] = p1.coefs[i] * n;
                return new Polynom(cs, p1.Degree);
            }
            public static Polynom operator *(double n, Polynom p1)
            {
                return p1 * n;
            }
            public override string ToString()
            {
                if (Degree != 0)
                {
                    string s = string.Empty;
                    for (int i = 0; i < Degree - 1; ++i)
                    {
                        if (Coefs[i] != 0) s += Coefs[i] + "x" + "^" + (Degree - i);
                        if (Coefs[i + 1] != 0) s += " + ";
                    }
                    if (Coefs[Degree - 1] != 0) s += Coefs[Degree - 1] + "x ";
                    s += " + " + Coefs[Degree];
                    return s;
                }
                return Coefs[0].ToString();
            }
            public double calculate(double x)
            {
                double value = 0;
                for (int i = 0; i < Degree + 1; ++i)
                    value += Coefs[i] * Math.Pow(x, i);
                ////Console.WriteLine("Значения многочлена для x = " + x + ": " + value + "\n");
                return value;
            }
            public double this[int i]
            {
                get { return Coefs[i]; }
                set { Coefs[i] = value; }
            }
            public double[] rootsSec()
            {
                double[] x = new double[2];
                x[0] = x[1] = 0;
                if (Degree == 2)
                {
                    double a = Coefs[0];
                    double b = Coefs[1];
                    double c = Coefs[2];
                    if ((b * b - 4 * a * c) >= 0) //Если дискриминант больше или равен 0
                    {
                        x[0] = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                        Console.Write("Первый корень: ");
                        //Console.WriteLine(x[0]);
                        x[1] = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
                        Console.Write("Второй корень: ");
                        //Console.WriteLine(x[1]);
                    }
                }
                return x;
            }
            public double[] Cardano()
            {
                if (Degree == 3)
                {
                    double a = Coefs[0];
                    double b = Coefs[1];
                    double c = Coefs[2];
                    double d = Coefs[3];
                    double eps = 1E-14;
                    double p = (3 * a * c - b * b) / (3 * a * a);
                    double q = (2 * b * b * b - 9 * a * b * c + 27 * a * a * d) / (27 * a * a * a);
                    double det = q * q / 4 + p * p * p / 27;
                    double[] x = new double[3];
                    if (Math.Abs(det) < eps)
                        det = 0;
                    if (det > 0)
                    {
                        // один вещественный, два комплексных корня
                        double u = -q / 2 + Math.Sqrt(det);
                        u = Math.Exp(Math.Log(u) / 3);
                        double yy = u - p / (3 * u);
                        x[0] = yy - b / (3 * a); // первый корень
                        x[1] = -(u - p / (3 * u)) / 2 - b / (3 * a);
                        x[2] = Math.Sqrt(3) / 2 * (u + p / (3 * u));
                    }
                    else
                    {
                        if (det < 0)
                        {
                            // три вещественных корня
                            double fi;
                            if (Math.Abs(q) < eps) // q=0
                                fi = Math.PI / 2;
                            else
                            {
                                if (q < 0)
                                    fi = Math.Atan(Math.Sqrt(-det) / (-q / 2));
                                else
                                    fi = Math.Atan(Math.Sqrt(-det) / (-q / 2)) + Math.PI;
                            }
                            double r = 2 * Math.Sqrt(-p / 3);
                            x[0] = r * Math.Cos(fi / 3) - b / (3 * a);
                            x[1] = r * Math.Cos((fi + 2 * Math.PI) / 3) - b / (3 * a);
                            x[2] = r * Math.Cos((fi + 4 * Math.PI) / 3) - b / (3 * a);
                        }
                        else // det=0
                        {
                            if (Math.Abs(q) < eps)
                            {
                                // 3-х кратный
                                x[0] = x[1] = x[2] = -b / (3 * a);
                            }
                            else
                            {
                                // один и два кратных
                                double u = Math.Exp(Math.Log(Math.Abs(q) / 2) / 3);
                                if (q < 0)
                                    u = -u;
                                x[0] = -2 * u - b / (3 * a);
                                x[1] = x[2] = u - b / (3 * a);
                            }
                        }
                    }
                    return x;
                }
                //Console.WriteLine("Многочлен не 3 степени");
                return null;
            }
            public double[] Ferr()
            {
                //a0x^4 + a1x^3 + a2x^2 + a3x + a4 = 0
                if (Degree == 4)
                {
                    double a0 = Coefs[0];

                    double a = Coefs[1] / a0;
                    double b = Coefs[2] / a0;
                    double c = Coefs[3] / a0;
                    double d = Coefs[4] / a0;
                    //x^4 + ax^3 + bx^2 + cx + d = 0
                    //x = y - a/4
                    double p = b - Math.Pow(a, 2) * 3 / 8;
                    double q = Math.Pow(a, 3) / 8 - a * b / 2 + c;
                    double r = -3 * Math.Pow(a, 4) / 256 + b * Math.Pow(a, 2) / 16 - a * c / 4 + d;
                    //y^4 + py^2 + qy + r = 0

                    // получится (y^2+s)^2 + (p-2s) * (y + q/(2(p-2s)))^2 + r - s^2 - q^2/(4(p-2s)) = 0
                    // далее следует выбрать s: (y^2+s)^2 + (p-2s) * (y + q/(2(p-2s)))^2 = 0
                    // найдем корни s и выберем какой-нибудь: 2s^3 - ps^2 - 2rs + rp - q^2/4 = 0
                    double[] arr1 = { 2, -p, -2 * r, r * p - Math.Pow(q, 2) / 4 };
                    Polynom poly3 = new Polynom(arr1, 3);
                    double[] roots = poly3.Cardano();
                    Complex[] rs = Complex.Cardano(2, -p, -2 * r, r * p - Math.Pow(q, 2) / 4);

                    double s = roots[0];
                    double[] x = new double[4];
                    x[0] = x[1] = x[2] = x[3] = a / 4;
                    double[] x1;
                    double[] arr = { 1, -Math.Sqrt(2 * s - p), s + q / (2 * Math.Sqrt(2 * s - p)) };
                    Polynom poly1 = new Polynom(arr, 2);
                    x1 = poly1.rootsSec();
                    if (x1 != null)
                    {
                        x[0] = x1[0];
                        x[1] = x1[1];
                    }

                    arr[1] = Math.Sqrt(2 * s - p);
                    arr[2] = s - q / (2 * Math.Sqrt(2 * s - p));
                    Polynom poly2 = new Polynom(arr, 2);
                    x1 = poly2.rootsSec();
                    if (x1 != null)
                    {
                        x[2] = x1[0];
                        x[3] = x1[1];
                    }
                    for (int i = 0; i < 4; ++i)
                        x[i] -= a / 4;

                    return x;
                }
                return null;
            }
        }

        public class OperationsOnPolinoms
        {
            private static bool chZero(ref double[] arr)
            {
                bool flag = true;
                int newLen = arr.Length;
                for (int i = 0; i < arr.Length; ++i, --newLen)
                    if (arr[i] != 0)
                    {
                        flag = false;
                        break;
                    }
                double[] tmp = (double[])arr.Clone();
                arr = new double[newLen];
                for (int i = 0; i < newLen; ++i)
                    arr[i] = tmp[i + tmp.Length - newLen];

                return flag;
            }

            public static void Div(Polynom dividend, Polynom divisor, out double[] quotient, out double[] remainder)
            {
                if (dividend[0] == 0)
                    throw new ArithmeticException("a0 == 0");
                if (divisor[0] == 0)
                    throw new ArithmeticException("a0 == 0");
                if (dividend.degree < divisor.degree)
                {
                    quotient = new double[] { 0 };
                    remainder = dividend.coefs;
                    return;
                }
                remainder = (double[])dividend.coefs.Clone();
                for (int i = 0; i < remainder.Length / 2; ++i)
                {
                    double t = remainder[i];
                    remainder[i] = remainder[dividend.coefs.Length - 1 - i];
                    remainder[dividend.coefs.Length - 1 - i] = t;
                }
                quotient = new double[remainder.Length - divisor.coefs.Length + 1];
                for (int i = 0; i < quotient.Length; ++i)
                {
                    double c = remainder[remainder.Length - i - 1] / divisor[0];
                    quotient[i] = c;
                    for (int j = 0; j < divisor.coefs.Length; ++j)
                        remainder[remainder.Length - i - j - 1] -= c * divisor[j];
                }
                for (int i = 0; i < remainder.Length / 2; ++i)
                {
                    double t = remainder[i];
                    remainder[i] = remainder[dividend.coefs.Length - 1 - i];
                    remainder[dividend.coefs.Length - 1 - i] = t;
                }
            }

            public static Polynom Gcd(Polynom p1, Polynom p2)
            {
                double[] q;
                double[] r1;
                double[] r2;
                Div(p1, p2, out q, out r1);
                if (chZero(ref r1))
                    return p2;
                Div(p2, p1, out q, out r2);
                if (chZero(ref r2))
                    return p1;
                if (p1.degree > p2.degree)
                    return Gcd(new Polynom(r1, r1.Length - 1), p2);
                return Gcd(p1, new Polynom(r2, r2.Length - 1));
            }

        }

        /// <summary>
        /// Класс, представляющий комплексное число
        /// </summary>
        public class Complex
        {
            /// <summary>
            /// Вещественная часть
            /// </summary>
            private double re;
            /// <summary>
            /// Мнимая часть
            /// </summary>
            private double im;

            /// <summary>
            /// Округление вещественной и мнимой частей комплексного числа до 4 знака после запятой
            /// </summary>
            /// <returns>Округлённое число</returns>
            public Complex Round()
            {
                re = Math.Round(re,4);
                im = Math.Round(im,4);
                return this;
            }
            /// <summary>
            /// Возвращает значение вещественной части
            /// </summary>
            /// <returns></returns>
            public double GetReal()
            {
                return re;
            }
            /// <summary>
            /// Возвращает значение мнимой части
            /// </summary>
            /// <returns></returns>
            public double GetImage()
            {
                return im;
            }

            /// <summary>
            /// Создает комплексное число с заданными параметрами
            /// </summary>
            /// <param name="re">Вещественная часть</param>
            /// <param name="im">Мнимая часть</param>
            public Complex(double re, double im)
            {
                this.re = re;
                this.im = im;
            }

            /// <summary>
            /// Создает комплексное число с нулевыми вещественной и мнимой частями
            /// </summary>
            public Complex()
            {
                this.re = 0;
                this.im = 0;
            }

            /// <summary>
            /// Возвращает копию комплексного числа
            /// </summary>
            /// <returns></returns>
            public Complex Copy()
            {
                return new Complex(this.re, this.im);
            }

            /// <summary>
            /// Возвращает строковое представление комплексного числа
            /// </summary>
            /// <returns></returns>
            override public String ToString()
            {
                return this.re.ToString() + "+" + this.im.ToString() + "i";
            }

            /// <summary>
            /// Возвращает модуль комплексного числа
            /// </summary>
            /// <returns></returns>
            public double Mod() 
            {
                return Math.Sqrt(Math.Pow(this.re, 2) + Math.Pow(this.im, 2));
            }

            /// <summary>
            /// Возвращает сумму двух комплексных чисел
            /// </summary>
            /// <param name="complex">Второе слагаемое</param>
            /// <returns></returns>
            public Complex Sum(Complex complex) 
            {
                return new Complex(this.re + complex.re, this.im + complex.im);
            }

            /// <summary>
            /// Возвращает разность двух комплексных чисел
            /// </summary>
            /// <param name="complex">Вычитаемое</param>
            /// <returns></returns>
            public Complex Diff(Complex complex)
            {
                return new Complex(this.re - complex.re, this.im - complex.im);
            }

            /// <summary>
            /// Возвращает произведение двух комплексных чисел
            /// </summary>
            /// <param name="complex">Второй множитель</param>
            /// <returns></returns>
            public Complex Mult(Complex complex) 
            {
                return new Complex(this.re * complex.re - this.im * complex.im, this.re * complex.im + this.im * complex.re);
            }

            /// <summary>
            /// Возвращает степень комплексного числа
            /// </summary>
            /// <param name="n">Значение степени</param>
            /// <returns></returns>
            /// <exception cref="IllegalArgumentException"></exception>
            public Complex Deg(int n)
            {
                if (n < 1) throw new IllegalArgumentException("Степень должна быть положительной");
                if (n == 1) return (this);
                return this.Mult(this.Deg(n - 1));
            }

            /// <summary>
            /// Возвращает частное двух комплексных чисел
            /// </summary>
            /// <param name="complex">Делитель</param>
            /// <returns></returns>
            /// <exception cref="ArithmeticException">Выбрасывается, если делитель нулевой</exception>
            public Complex Div(Complex complex) 
            {
                double z = complex.Mod() * complex.Mod();
                if (z == 0) throw new ArithmeticException("Деление невозможно");
                Complex c = complex.Copy();
                c.im = -c.im;
                Complex c1 = this.Mult(c);
                c1.re /= z;
                c1.im /= z;
                return c1;
            }

            /// <summary>
            /// Находит все корни из комплексного числа заданной степени
            /// </summary>
            /// <param name="n">Степень</param>
            /// <returns>Массив комплексных чисел, представляющий корни</returns>
            /// <exception cref="IllegalArgumentException">Выбрасывается, если степень неположительная</exception>
            /// <exception cref="ArithmeticException">Выбрасывается, если корней не существует</exception>
            public Complex[] Roots(int n) 
            {
                if (n <= 0) throw new IllegalArgumentException("Степень должна быть положительной");
                if (this.Mod() == 0) throw new ArithmeticException("Корней не существует");
                Complex[] roots = new Complex[n];
                double arg, temp, x = this.re, y = this.im, z = Math.Atan(Math.Abs(y / x)), k = Math.Pow(this.Mod(), 1.0 / n), pi = Math.PI;
                if (x > 0)
                {
                    if (y >= 0) arg = z;
                    else arg = 2 * pi - z;
                }
                else if (x < 0)
                {
                    if (y >= 0) arg = pi - z;
                    else arg = pi + z;
                }
                else
                {
                    if (y > 0) arg = pi / 2;
                    else arg = 3 * pi / 2;
                }
                for (int i = 0; i < n; ++i)
                {
                    temp = (arg + 2 * pi * i) / n;
                    roots[i] = new Complex(k * Math.Cos(temp), k * Math.Sin(temp));
                }
                return roots;
            }

            /// <summary>
            /// Решает уравнение ax^3_bx^2+cx+d=0
            /// </summary>
            /// <param name="a">a</param>
            /// <param name="b">b</param>
            /// <param name="c">c</param>
            /// <param name="d">d</param>
            /// <returns>Массив комплексных чисел, представляющий решения</returns>
            public static Complex[] Cardano(double a, double b, double c, double d) 
            {
                double p = (3 * a * c - b * b) / 3 * a * a, q = (2 * b * b * b - 9 * a * b * c + 27 * a * a * d) / 27 * a * a * a;
                double Q = Math.Pow(p / 3, 3) + Math.Pow(q / 2, 2);
                Complex[] roots_Q = new Complex(Q, 0).Roots(2);
                Complex[] roots_a = new Complex(-q / 2, 0).Sum(roots_Q[0]).Roots(3);
                Complex[] roots_b = new Complex(-q / 2, 0).Sum(roots_Q[1]).Roots(3);
                double eps = Math.Pow(1.0, -18);
                Complex complex = new Complex();
                Complex x = roots_a[0], y = complex;
                for (int j = 0; j < 3; ++j)
                {
                    if (x.Mult(roots_b[j]).GetReal() + (p / 3) < eps)
                    {
                        y = roots_b[j];
                    }
                }
                Complex x1 = x.Sum(y).Div(new Complex(-0.5, 0));
                Complex y1 = x.Diff(y).Mult(new Complex(0, Math.Sqrt(3) / 2));
                Complex s = new Complex(-b / 3 * a, 0);
                Complex[] roots = new Complex[3];
                Complex z0 = x.Sum(y), z1 = x1.Sum(y1), z2 = x1.Diff(y1);
                roots[0] = z0.Diff(s);
                roots[1] = z1.Diff(s);
                roots[2] = z2.Diff(s);
                return roots;
            }
        }

        [Serializable]
        internal class IllegalArgumentException : Exception
        {
            public IllegalArgumentException()
            {
            }

            public IllegalArgumentException(string message) : base(message)
            {
            }

            public IllegalArgumentException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected IllegalArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        public class NumberTheory
        {
            /// <summary>
            /// Вычисляет наибольший общий делитель двух чисел
            /// </summary>
            /// <param name="num1">Первое число</param>
            /// <param name="num2">Второе число</param>
            /// <returns>наибольший общий делитель</returns>
            /// <exception cref="ArgumentException">Выбрасывается, если хотя бы одно из чисел равно нулю</exception>
            public static int GCD(int num1, int num2) //НОД
            {
                if (num1 < 0) num1 *= -1;
                if (num2 < 0) num2 *= -1;
                if (num1 == 0 || num2 == 0) throw new ArgumentException("Некорректные аргументы");
                int temp;
                do
                {
                    if (num1 < num2)
                    {
                        temp = num1;
                        num1 = num2;
                        num2 = temp;
                    }
                    num1 %= num2;
                }
                while (num1 > 0);
                return num2;
            }

            public static uint GCD1(uint num1, uint num2) //Рекурсивный алгоритсм, GCD > GCD1 
            {
                if (num1 == 0 || num2 == 0) throw new ArgumentException("Некорректные аргументы");
                if (num1 % num2 == 0) return num2;
                else return GCD1(num2, num1 % num2);
            }
            /// <summary>
            /// Класс особого числа, которое хранит значение числа, и число вхождений этого числа в разложении на простые множители
            /// </summary>
            public class Number
            {
                /// <summary>
                /// Значение числа
                /// </summary>
                public uint value;
                /// <summary>
                /// Число вхождений в разложении
                /// </summary>
                public uint deg;

                /// <summary>
                /// Создаёт особое число с заданными параметрами
                /// </summary>
                /// <param name="value">Значение числа</param>
                /// <param name="deg">Число вхождений в разложении</param>
                public Number(uint value, uint deg)
                {
                    this.value = value;
                    this.deg = deg;
                }
            }
            /// <summary>
            /// Вычисляет наименьшее общее кратное двух чисел
            /// </summary>
            /// <param name="num1">Первое число</param>
            /// <param name="num2">Второе число</param>
            /// <returns>наименьшее общее кратное</returns>
            public static int SCM(int num1, int num2) //НОК
            {
                return Math.Abs(num1 * num2) / GCD(num1, num2);
            }
            /// <summary>
            /// Находит число делителей заданного числа
            /// </summary>
            /// <param name="num">Число</param>
            /// <returns>Число делителей</returns>
            /// <exception cref="ArgumentException">Выбрасывается, если число равно единице или нулю</exception>
            public static uint CountOfDivisors(uint num) //Число делителей
            {
                if (num == 1 || num == 0) throw new ArgumentException("Единицу или ноль нельзя разложить на простые множители");
                uint count = 0;
                double s = Math.Sqrt(num);
                for (uint i = 2; i <= s; ++i) if (num % i == 0) count += 2;
                if (s / Math.Round(s) == 1) --count;
                return ++count;
            }
            /// <summary>
            /// Раскладывает число на простые множители
            /// </summary>
            /// <param name="num">Число</param>
            /// <returns>Список особых чисел, представляющих число и степень вхождения в разложении</returns>
            /// <exception cref="ArgumentException">Выбрасывается, если число равно единице</exception>
            public static List<Number> PrimeFactorization(uint num) 
            {
                if (num == 1) throw new ArgumentException("Единицу нельзя разложить на простые множители");
                else
                {
                    List<uint> PrimeList = new List<uint>(); //Список простых делителей
                    if (num % 2 == 0) PrimeList.Add(2);
                    for (uint i = 3; i <= num / 2; i += 2) if (num % i == 0 && CountOfDivisors(i) == 1) PrimeList.Add(i);
                    if (CountOfDivisors(num) == 1 && num != 2) PrimeList.Add(num);
                    List<Number> NumbersList = new List<Number>();
                    uint curValue, curDeg = 0;
                    for (int i = 0; i < PrimeList.Count; ++i)
                    {
                        curValue = PrimeList[i];
                        while (num % curValue == 0)
                        {
                            ++curDeg;
                            num /= curValue;
                        }
                        Number curNumber = new Number(curValue, curDeg);
                        NumbersList.Add(curNumber);
                        curDeg = 0;
                    }
                    return NumbersList;
                }
            }

            /// <summary>
            /// Вычисляет значение функции Эйлера в точке
            /// </summary>
            /// <param name="num">Точка</param>
            /// <returns>Значение функции Эйлера в этой точке</returns>
            /// <exception cref="ArgumentException">Выбрасывается, если введено ненатуральное число</exception>
            public static uint EulerFunction(uint num) 
            {
                if (num == 0) throw new ArgumentException("Введите натуральное число");
                else if (num == 1) return 1;
                else
                {
                    uint res = 1;
                    List<Number> numbers = PrimeFactorization(num);
                    foreach (Number item in numbers)
                    {
                        res *= (item.value - 1) * (uint)Math.Pow(item.value, item.deg - 1);
                    }
                    return res;
                }
            }
            
            /// <summary>
            /// Переводит рациональную дробь в цепную 
            /// </summary>
            /// <param name="numerator">Числитель</param>
            /// <param name="denominator">Знаменатель</param>
            /// <returns>Список, представляющий коэффициенты в цепном разложении</returns>
            /// <exception cref="ArgumentException">Выбрасывается, если знаменатель нулевой</exception>
            public static List<int> RationalToContinuedFraction(int numerator, int denominator) 
            {
                if (denominator == 0) throw new ArgumentException("Введите ненулевой знаменатель");
                else if (denominator < 0)
                {
                    numerator *= -1;
                    denominator *= -1;
                }
                List<int> chainComponents = new List<int>();
                int diff, temp, k, r;
                if (numerator < 0 && numerator % denominator != 0) diff = numerator / denominator - 1;
                else diff = numerator / denominator;
                chainComponents.Add(diff);
                numerator = numerator - diff * denominator;
                r = numerator % denominator;
                while (r != 0)
                {
                    if (numerator < denominator)
                    {
                        temp = numerator;
                        numerator = denominator;
                        denominator = temp;
                    }
                    k = numerator / denominator;
                    r = numerator % denominator;
                    chainComponents.Add(k);
                    numerator = denominator;
                    denominator = r;
                }
                return chainComponents;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="num1"></param>
            /// <param name="num2"></param>
            /// <returns></returns>
            /// <exception cref="ArgumentException"></exception>
            public static int[] AdvancedEuclidAlgorithm(int num1, int num2)
            {
                if (num1 == 0 || num2 == 0) throw new ArgumentException("Некорректные аргументы");
                int[] qi;
                bool isSwapped = false;
                if (num1 < num2)
                {
                    qi = RationalToContinuedFraction((int)num2, (int)num1).ToArray();
                    isSwapped = true;
                }
                else qi = RationalToContinuedFraction((int)num1, (int)num2).ToArray();
                int size = qi.Length;
                int[] Pi = new int[size], Qi = new int[size];
                int[] values = new int[3];
                int nod = (int)GCD(Math.Abs(num1), Math.Abs(num2));
                if (size > 2)
                {
                    Pi[0] = qi[0];
                    Qi[0] = 1;
                    Pi[1] = Pi[0] * qi[1] + 1;
                    Qi[1] = qi[1];
                    for (int i = 2; i < size; i++)
                    {
                        Pi[i] = Pi[i - 1] * qi[i] + Pi[i - 2];
                        Qi[i] = Qi[i - 1] * qi[i] + Qi[i - 2];
                    }
                    if (size - 1 % 2 == 0)
                    {
                        if (!isSwapped)
                        {
                            values[0] = -Qi[size - 2];
                            values[1] = Pi[size - 2];
                        }
                        else
                        {
                            values[0] = Pi[size - 2];
                            values[1] = -Qi[size - 2];
                        }
                    }
                    else
                    {
                        if (!isSwapped)
                        {
                            values[0] = Qi[size - 2];
                            values[1] = -Pi[size - 2];
                        }
                        else
                        {
                            values[0] = -Pi[size - 2];
                            values[1] = Qi[size - 2];
                        }
                    }
                }
                else if (size == 1)
                {
                    if (!isSwapped)
                    {
                        values[0] = 1;
                        values[1] = -qi[0] + 1;
                    }
                    else
                    {
                        values[0] = -qi[0] + 1;
                        values[1] = 1;
                    }
                }
                else
                {
                    if (!isSwapped)
                    {
                        values[0] = 1;
                        values[1] = -qi[0];
                    }
                    else
                    {
                        values[0] = -qi[0];
                        values[1] = 1;
                    }
                }
                values[2] = nod;
                return values;
            }
            /// <summary>
            /// Решает диофантово уравнение ax+by=c
            /// </summary>
            /// <param name="a">Коэффициент a</param>
            /// <param name="b">Коэффициент b</param>
            /// <param name="c">Коэффициент c</param>
            /// <returns>Строка, являющаяся решением диофантова уравнения</returns>
            public static string DiophantineEquation(int a, int b, int c)
            {
                if (c % GCD(a, b) != 0) return "Решений нет";
                bool change = false;
                if (c < 0)
                {
                    c *= -1;
                    a *= -1;
                    b *= -1;
                    change = true;
                }
                int[] arr = AdvancedEuclidAlgorithm(a, b);
                string str = string.Empty;
                if (change)
                {
                    str += "x = " + (-c * arr[0]).ToString() + " + " + (-b).ToString() + "k\r\n";
                    str += "y = " + (-c * arr[1]).ToString() + " + " + (a).ToString() + "k";
                }
                else
                {
                    str += "x = " + (c * arr[0]).ToString() + " + " + b.ToString() + "k\r\n";
                    str += "y = " + (c * arr[1]).ToString() + " + " + (-a).ToString() + "k";
                }
                return str;
            }
        }
    }
}
