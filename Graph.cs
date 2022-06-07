using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Professional_GUI
{


    abstract class Graphs
    {
        protected int SIZE = 16;
        protected int realSize;
        protected int countVertexs = 0;

        protected bool symmetry = true;

        public void setSymm(bool bl) {
            symmetry = bl;
        }
        public bool getSymm()
        {
                return symmetry;
        }

        public void setRealsize(int t) {
            realSize = t;
        }
        public int getRealSize()
        {
            return realSize;
        }

        abstract public void resize();


        abstract public void RemoveEl(int n);

            abstract public void addVertex(System.Drawing.Point p);
            abstract public string colorTheGraph();

            abstract        public string humiltonCycle();
        abstract public string Elrcycel();
        abstract public string stronglyComponents();
    }

        class Adjacency_matr : Graphs
        {

        public Adjacency_matr(int rlSz) {
            realSize= rlSz;
            matr = new Vertex<int>[SIZE];
            for (int i = 0; i < realSize; i++)
            {
                int[] mas = new int[SIZE];
                matr[i] = new Vertex<int>(mas,i);

            }
        }

        private Vertex<int>[] matr;

       public  Vertex<int> GetVertex(int i) {
            return matr[i];
        }
        public override void resize()
        {//не проверял
            SIZE *= 2;
            Array.Resize<Vertex<int>>(ref matr, SIZE);
            for (int i = SIZE / 2; i < SIZE; i++)
                matr[i] = new Vertex<int>(SIZE,i);
            for (int i = 0; i < SIZE/2; i++)
                Array.Resize<int>(ref matr[i].getCompound(), SIZE);
        }
        public override void RemoveEl(int num)
        {
            if (num > 0 && num <= realSize)
            {
                for (int i = num - 1; i < realSize - 1; i++)
                    matr[i] = matr[i + 1];
                for (int i = 0; i < realSize - 1; i++)
                    for (int j = num - 1; j < realSize - 1; j++)
                        matr[i].addEl(j, matr[i].getEl(j + 1));

                --realSize;
            }
            else
            {
                //ERROR
            }
        }

        public void addCompound(int i,int j) {
            int[] m= matr[i].getCompound();
            if(m[j]!=int.MaxValue)
               m[j] += 1;
            else
               m[j] = 1;
            if (symmetry)
            {
                m= matr[j].getCompound();
                if (m[i] != int.MaxValue)
                    m[i] += 1;
                else
                    m[i] = 1;
            }
        }

        public override void addVertex(System.Drawing.Point p)
        { 
            ++countVertexs;
            if (++realSize > SIZE)
                resize();
            int[] mHlp = new int[SIZE];
            matr[realSize - 1] = new Vertex<int>(mHlp, p,countVertexs-1);
            int[] mHlp2 = new int[SIZE];
            for (int i = 0; i < realSize; i++)//??
            {
                mHlp[i] = int.MaxValue;
                mHlp2[i] = int.MaxValue;
            }
            for (int i = 0; i < realSize - 1; i++)
            {
                    matr[i].addEl(realSize - 1, mHlp2[i]);
            }
        }
            public Adjacency_matr()
            {
                matr = new Vertex<int>[SIZE];
                for (int i = 0; i < realSize; i++)
                {
                    int[] mas = new int[SIZE];
                        matr[i] = new Vertex<int>(mas,i);
           
                }
            }

            public Adjacency_matr(ref Vertex<double>[] matrOfDbl, int rlsz)//переделать,чтобы в взвешенной матрице,при добавлении врешины,эта тоже матрциа изменялась
            {
                realSize = rlsz;
                SIZE = 2 * rlsz;
                matr = new Vertex<int>[SIZE];
                for (int i = 0; i < rlsz; i++)
                {
                    int[] mas = new int[SIZE];
                    for (int j = 0; j < rlsz; j++)
                        if (matrOfDbl[i].getEl(j) != double.PositiveInfinity)
                            mas[j] = 1;
                        else
                            mas[j] = int.MaxValue;
                    matr[i] = new Vertex<int>(mas,i);
                }
            }

        //////////////////////////////////
        /////////////////////////////////
        public override string colorTheGraph()//
        {
            string[] colors = new string[] { "белый", "черный", "красный", "зеленый", "синий", "орнажевый", "коричневый", "голубой", "фиолетовый", "бежевый", "лазурный", "изумрудный", "Бирюзовый", "бистр", "арлекин", "бордовый", "маренго", "сливовый", "серый" };
            ver_deg[] mas = new ver_deg[realSize];
            for (int i = 0; i < realSize; i++)
            {
                mas[i].ver = i;
                for (int j = 0; j < realSize; j++)
                    if (matr[i].getEl(j) != int.MaxValue)
                        mas[i].deg++;
            }
            Array.Sort(mas, new Comparison<ver_deg>((a, b) => a.deg.CompareTo(b.deg)));//Переделать
            Array.Reverse(mas, 0, mas.Length);
            List<ver_deg> ListVer = mas.ToList();
            StringBuilder result = new StringBuilder();
            int[] clrs = new int[realSize];
            for (int i = 0; i < realSize; i++)
                clrs[i] = -1;
            int[] hlp = new int[realSize];//содержит места вершин в mas
            for (int i = 0; i < realSize; i++)
                for (int j = 0; j < realSize; j++)
                    if (i == mas[j].ver)
                    {
                        hlp[i] = j;
                        break;
                    }
            for (int i = 0; i < realSize; i++)
            {
                int k = 0;
                for (int j = 0; j < realSize; j++)
                    if ((matr[mas[i].ver].getEl(j) != int.MaxValue || matr[j].getEl(mas[i].ver) != int.MaxValue) && clrs[mas[hlp[j]].ver] == k)// + не посещаем уже раскрашенные
                    {
                        ++k;
                        j = 0;
                    }

                clrs[mas[i].ver] = k;
                if (k < colors.Length)
                    result.Append((mas[i].ver + 1) + " - " + colors[k] + "    ");
                else
                    result.Append((mas[i].ver + 1) + " - " + colors[k % colors.Length] + k % colors.Length + "    ");
            }
            return result.ToString();
        }

        public override string humiltonCycle()
            {//Сделать условие на колво элементов(т.к. работает за O(n!))!!!
                bool[] Visited = new bool[realSize];
                List<int> Path = new List<int>();
                StringBuilder res = new StringBuilder();
                if (humilton(0, Visited, Path))
                {
                    for (int i = 0; i < realSize; i++)
                        res.Append((Path[i] + 1) + "=>");
                    res.Append(Path[0] + 1);
                    return res.ToString();
                }
                return "Цикла не существует";
            }


            bool humilton(int curr, bool[] Visited, List<int> Path)//переделать через массивы
            {
                Path.Add(curr);
                if (Path.Count == realSize)
                    if (matr[curr].getEl(Path[Path[0]]) != int.MaxValue)
                        return true;
                    else
                    {
                        Path.RemoveAt(Path.Count - 1);
                        return false;
                    }
                Visited[curr] = true;
                for (int nxt = 0; nxt < realSize; ++nxt)
                    if (matr[curr].getEl(nxt) != int.MaxValue && !Visited[nxt])
                        if (humilton(nxt, Visited, Path))//лучше передавать по ссылке 
                            return true;
                Visited[curr] = false;
                Path.RemoveAt(Path.Count - 1);
                return false;
            }
             


            public override string Elrcycel()//только для неориентированного графа
            {
            
                StringBuilder result = new StringBuilder();
            bool bad = false;//флаг для определения существования эйлеровости графа
            int[,] g = new int[realSize, realSize];
            for (int i = 0; i < realSize; i++)
                for (int j = 0; j < realSize; j++)
                {
                    if (matr[i].getEl(j) != int.MaxValue)
                        g[i, j] = matr[i].getEl(j);
                    else
                        g[i, j] = 0;
                }
            int[] deg = new int[realSize];
                for (int i = 0; i < realSize; ++i)
                    for (int j = 0; j < realSize; ++j)
                        deg[i] += g[i, j];//cчитаем четность степени вершины

                int first = 0;
                while (first<realSize &&!Convert.ToBoolean(deg[first])) ++first;//считаем число изолированных вершин до первой не изолированной
            if (first == realSize) bad = true;
                int v1 = -1, v2 = -1;
            
                for (int i = 0; i < realSize; ++i)//по т. о рукопожатиях число вершин с нечет сетпенями четно
                    if (Convert.ToBoolean(deg[i] & 1))//если число степеней вершины нечетно
                        if (v1 == -1)//если более двух веришн с нечетным числом степеней,то граф не Эйлеров
                            v1 = i;
                        else if (v2 == -1)//если 2 вершины с нечет степенями,то есть только Эйлеров путь!!!!
                            v2 = i;
                        else
                            bad = true;

            for (int i = 0; i < realSize; i++)
                for (int j = 0; j < i + 1; j++)
                    if (g[i, j] != g[j, i])
                        bad = true;
            if (bad)
            {
                    result.Append("Эйлеров цикл/путь не сущесвтвует");
            }
            else
            {
                if (v1 != -1)//не равно -1=>Эйлеров путь,создаем ребро между v1 и v2,потом его удалим
                { ++g[v1, v2]; ++g[v2, v1]; }

                Stack<int> st = new Stack<int>();
                st.Push(first);//добавляем первую не изолированную вершину
                List<int> res = new List<int>();
                while (Convert.ToBoolean(st.Count()))//пока стек не пустой 
                {
                    int v = st.Peek();
                    int i;
                    for (i = 0; i < realSize; ++i)
                        if (Convert.ToBoolean(g[v, i]))//ищем ребро
                            break;
                    if (i == realSize)//если нет ребра из v в i, то веришна изолирована
                    {
                        res.Add(v);
                        st.Pop();//извлекаем и стека,т.к. она не цикл
                    }
                    else//если есть ребро
                    {
                        --g[v, i];//удаляем ребро
                        --g[i, v];//?????????? мб иф
                        st.Push(i);//добавляем в стек
                    }
                }

                if (v1 != -1)//если это Эйлеров путь
                    for (int i = 0; i + 1 < res.Count; ++i)
                        if (res[i] == v1 && res[i + 1] == v2 || res[i] == v2 && res[i + 1] == v1)
                        {//если и-тая веришна ==перовй врешине с нечет стпенью и и+1-я второй(или наоборот) 
                            List<int> res2 = new List<int>();//'удаляем' добавленное ребро
                            for (int j = i + 1; j < res.Count; ++j)
                                res2.Add(res[j]);
                            for (int j = 1; j <= i; ++j)
                                res2.Add(res[j]);
                            res = res2;
                            break;
                        }

                for (int i = 0; i < realSize; ++i)
                    for (int j = 0; j < realSize; ++j)
                        if (Convert.ToBoolean(g[i, j]))//если в изменной матрице остались ребра,то она граф не Эйлеров
                            bad = true;
                if (bad)
                {
                     return ("Эйлеров цикл/путь не сущесвтвует");
                }

                for (int i = 0; i < res.Count; ++i)
                        result.Append(res[i] + 1 + "=>");
               
            }
            result.Remove(result.Length-2, 2);
            return result.ToString();
        }
            void dfs(int curr, int[] tout, ref int counter, bool[] used)
            {//обход в глубину для компонент связности
                used[curr] = true;
                for (int i = 0; i < realSize; i++)
                    if (matr[curr].getEl(i) != int.MaxValue && !used[i])
                    {
                        ++counter;
                        dfs(i, tout, ref counter, used);
                    }
                tout[curr] = counter++;
            }

            void dfsForInvGraph(List<int> components, int curr, bool[] used, int[] tout)
            {
                used[curr] = true;
                tout[curr] = 0;
                components.Add(curr);
                for (int i = 0; i < realSize; i++)
                    if (matr[i].getEl(curr) != int.MaxValue && !used[i])
                    {
                        used[i] = true;
                        dfsForInvGraph(components, i, used, tout);
                    }
            }
            List<List<int>> stronglyConnectedComponents()
            {
                List<List<int>> components = new List<List<int>>();
                int k = 1;
                int[] tout = new int[realSize];
                bool[] used = new bool[realSize];
                for (int i = 0; i < realSize; ++i)
                    if (!used[i])
                        dfs(i, tout, ref k, used);
                for (int i = 0; i < realSize; ++i) used[i] = false;
                int t = tout.Max();
                while (t != 0)
                {
                    List<int> cmpn = new List<int>();
                    dfsForInvGraph(cmpn, Array.IndexOf(tout, t), used, tout);
                    components.Add(cmpn);
                    t = tout.Max();
                }
                return components;
            }

            public override string stronglyComponents()
            {
                List<List<int>> components = stronglyConnectedComponents();
                StringBuilder str = new StringBuilder();
                foreach (List<int> i in components)
                {
                    str.Append("|");
                    foreach (int j in i)
                        str.Append((j + 1).ToString() + ",");
                str= str.Remove(str.Length-1,1);
                    str.Append("| ");
                }
                return str.ToString();
            }
        }



        class Weighted_matrix : Graphs
    {
        private Vertex<double>[] matr;
        Adjacency_matr adjacency = null;


        public Weighted_matrix(int rlSz)
        {
            realSize = rlSz;
            matr = new Vertex<double>[SIZE];
            for (int i = 0; i < realSize; i++)
            {
                double[] mas = new double[SIZE];
                matr[i] = new Vertex<double>(mas,i);

            }
        }
        public override void resize()
        {//не проверял
            SIZE *= 2;
            Array.Resize<Vertex<double>>(ref matr, SIZE);
            for (int i = SIZE / 2; i < SIZE; i++)
                matr[i] = new Vertex<double>(SIZE,i);
            for (int i = 0; i < SIZE / 2; i++)
                Array.Resize<double>(ref matr[i].getCompound(), SIZE);
        }
        public override void RemoveEl(int num)
        {
            if (num > 0 && num <= realSize)
            {
                for (int i = num - 1; i < realSize - 1; i++)
                    matr[i] = matr[i + 1];
                for (int i = 0; i < realSize - 1; i++)
                    for (int j = num - 1; j < realSize - 1; j++)
                        matr[i].addEl(j, matr[i].getEl(j + 1));

                --realSize;
            }
            else
            {
                //ERROR
            }
        }


        public override void addVertex(System.Drawing.Point p)
            {
            //if (++realSize > SIZE)
            //    resize();

            //double[] mHlp = new double[SIZE];
            //matr[realSize - 1] = new Vertex<double>(mHlp);
            //double[] mHlp2 = new double[SIZE];
            //for (int i = 0; i < realSize - 1; i++)
            //    matr[i].addEl(realSize - 1, mHlp2[i]);
            ++countVertexs;
            if (++realSize > SIZE)
                resize();
            double[] mHlp = new double[SIZE];
            matr[realSize - 1] = new Vertex<double>(mHlp, p,countVertexs-1);
            double[] mHlp2 = new double[SIZE];
            for (int i = 0; i < realSize; i++)//??
            {
                mHlp[i] = double.PositiveInfinity;
                mHlp2[i] = double.PositiveInfinity;
            }
            for (int i = 0; i < realSize - 1; i++)
            {
                matr[i].addEl(realSize - 1, mHlp2[i]);
            }
        }
            public Weighted_matrix()
            {
            matr = new Vertex<double>[SIZE];
            for (int i = 0; i < realSize; i++)
            {
                double[] mas = new double[SIZE];
                matr[i] = new Vertex<double>(mas,i);

            }
        }

        public Vertex<double> GetVertex(int i)
        {
            return matr[i];
        }

        public void addCompound(int i, int j,double vl)
        {
            double[] m = matr[i].getCompound();
                m[j] = vl;
            if (symmetry)
            {
                m = matr[j].getCompound();
                m[i] = vl;
            }
        }

        public void removeCompound(int i, int j)
        {
            double[] m = matr[i].getCompound();
            m[j] = double.PositiveInfinity;
            if (symmetry)
            {
                m = matr[j].getCompound();
                m[i] = double.PositiveInfinity;
            }
        }

        /// <summary>
        /// ///////////////////////////////////////
        /// </summary>
        /// <returns></returns>



        double[] searchOfMinDeikstri(int xBeg)
            {//функция поиска мин-го пути
                double[][] matrixD = new double[realSize][];//\\поробовать обойтись двустрочной матрицей
                for (int i = 0; i < realSize; i++)//создание таблицы для запоминания путей от начй вершины до всех верш-н
                {
                    matrixD[i] = new double[realSize];
                    for (int j = 0; j < realSize; j++)
                        matrixD[i][j] = Double.PositiveInfinity;
                }
                matrixD[0][xBeg] = 0;//устанавливаем в таблице,что от начй до начй вершины путь = 0
                double[] masOfMinLen = new double[realSize];//массив минмальных путей до всех вершин
                Array.Copy(matr[xBeg].getCompound(), 0, masOfMinLen, 0, realSize);
                // matr[xBeg].getCompound().CopyTo(masOfMinLen, 0,realSize);//по умолчанию минимальный пути равны весам ребер выходящих из xBeg
                List<int> listOfVisitedVertex = new List<int>();//список уже пройденных вершин\\можно заменить на массив
                int xi = xBeg;//перменная посещенной вершины
                double min = 0;
                for (int i = 0; i < realSize - 1; i++)//поиск минимального пути,обязательно ли n итерация для посика мин-го пути для любой вершины??
                {
                    listOfVisitedVertex.Add(xi);//добавляем веришну в список посещенных
                    masOfMinLen[xi] = min;//добавляем длину до этой вершины в массив мин-х расстояний от xBeg до остальных вершин
                for (int j = 0; j < realSize; j++)
                    if (listOfVisitedVertex.FindIndex(x => x == j) == -1)
                    {//если вершина посещена,то пропускаем ее(не заносим в таблицу)
                        matrixD[i + 1][j] = Math.Min(matrixD[i][j], min + matr[xi].getEl(j));
                    }
                    //заносим в таблицу минимум из:"min(старый путь,новый путь + путь от xi до веришны j)"
                    min = matrixD[i + 1].Min();//находим минимум из всех значений строки таблицы
                    xi = Array.IndexOf(matrixD[i + 1], min);//находим данную вершину,до которой путь = min
                }
                masOfMinLen[xi] = min;//добавляем минимальное расстояние до последней вершины
                return masOfMinLen;
            }

           private string searchOfChainMinWayDeikstri(int xBeg, int xEnd, in double[] masOfMinLen)
            {
            if (masOfMinLen[xEnd] == double.PositiveInfinity)
                return "Пути не существует";
                Stack<int> chain = new Stack<int>();//стек,т.к. мы ищем путь последовательно,начиная от xEnd
                int xi = xEnd;
                chain.Push(xEnd + 1);//+1,т.к. мы нумеруем вершины в матрце начиная с 0
                for (int i = 0; xi != xBeg; ++i)
                    for (int j = 0; j < realSize; j++)
                        if (matr[j].getEl(xi) != 0 && masOfMinLen[xi] == matr[j].getEl(xi) + masOfMinLen[j])
                        {//если в вершину xi есть прямой путь из j и его сумма с предшедвствующим ему равна min-му пути,то добавляем вершину
                            chain.Push(j + 1);//\\пофиксить,чтобы он ветвился
                            xi = j;
                        }
                StringBuilder str = new StringBuilder(masOfMinLen[xEnd] + " ");
                for (int i = 0; chain.Count != 0; i++)
                    str.Append(chain.Pop() + "-");
                str.Remove(str.Length - 1, 1);
                return str.ToString();
            }

            public string AlgorithmDeikstri(int xBeg, int xEnd)//если ошибка,то вероятнее всего такого маршрута не существует
            {
            for (int i = 0; i < realSize; i++)
                for (int j = 0; j < realSize; j++)
                    if (matr[i].getEl(j) < 0)
                        return "Граф не является положительным";
                double[] masOfMinLen = searchOfMinDeikstri(xBeg);//функция поиска мин-го пути,изменяет masOfMinLen
                return searchOfChainMinWayDeikstri(xBeg, xEnd, masOfMinLen);//функция поиска цепи манимального пути
            }

            string searchOfChainFloidaFirst(int[][] p, int xBeg, int xEnd)
            {//Восстановление пути алгоритма Флойда(рекурсивно)
                StringBuilder str = new StringBuilder();
                if (p[xBeg][xEnd] != 0)
                    str.Append(searchOfChainFloidaFirst(p, xBeg, p[xBeg][xEnd]));

                return str.Append((xEnd + 1).ToString()).ToString() + "-";
            }

            double[][] searchOfMinFloid(int[][] p)
            {
                double[][] d = new double[realSize][];//\\поробовать обойтись двустрочной матрицей
                for (int i = 0; i < realSize; i++)//создание таблицы для запоминания путей от начй вершины до всех верш-н
                {
                    d[i] = new double[realSize];
                    for (int j = 0; j < realSize; j++)
                        if (i == j)
                            d[i][j] = 0;
                        else
                            d[i][j] = matr[i].getEl(j);
                }
                double help;
                for (int k = 0; k < realSize; ++k)
                    for (int i = 0; i < realSize; ++i)
                        for (int j = 0; j < realSize; ++j)
                            if (d[i][k] < double.PositiveInfinity && d[k][j] < double.PositiveInfinity)
                            {
                                help = d[i][j];
                                d[i][j] = Math.Min(d[i][j], d[i][k] + d[k][j]);
                                if (d[i][i] < 0)
                                return null;
                                if (p != null && help != d[i][j])
                                    p[i][j] = k;
                            }
                return d;
            }

            public string algoritgmFloida(int xBeg, int xEnd)
            {//Алгоритм флойда(поиск мин-го пути с отрицательными весами)
                int[][] p = new int[realSize][];//\\поробовать обойтись двустрочной матрицей
                for (int i = 0; i < realSize; i++)//создание таблицы для запоминания путей от начй вершины до всех верш-н
                {
                    p[i] = new int[realSize];
                }
                double[][] d = searchOfMinFloid(p);
            if (d != null)
            {
                string first = searchOfChainFloidaFirst(p, xBeg, xEnd), second = searchOfChainFloidaFirst(p, p[xBeg][xEnd], xEnd);
                if (d[xBeg][xEnd] == double.PositiveInfinity)
                    return "Пути не существует";
                if (first.Length >= 3)
                    return d[xBeg][xEnd].ToString() + "       " + (xBeg + 1) + "-" + first.Remove(first.Length - 3, 2) + second.Remove(second.Length - 1, 1);
                return d[xBeg][xEnd].ToString() + "       " + (xBeg + 1) + "-" + first.Remove(Math.Abs(first.Length - 1), 1);
            }
            return "В графе существует отрицательный цикл";
        }

        public int MedianDeikstri()
            {//Медиана для положительного графа\\переделать и на отрицательный
                double[] masOfMinLen, masOfSum = new double[realSize];
                for (int xi = 0; xi < realSize; xi++)
                {
                    masOfMinLen = searchOfMinDeikstri(xi);
                    masOfSum[xi] = masOfMinLen.Sum();
                }
                return Array.IndexOf(masOfSum, masOfSum.Min()) + 1;
            }
        public string MedianFloida()
        {//для отрицательный отрицательного графа
            bool[] vis = new bool[realSize];
            if (dfsS(0, ref vis) == realSize)
            {
                double[] masOfSum = new double[realSize];
                double[][] masOfMinWay = searchOfMinFloid(null);
                if (masOfMinWay != null)
                {
                    for (int xi = 0; xi < realSize; xi++)
                        masOfSum[xi] = masOfMinWay[xi].Sum();
                    return "Медиана: " + Convert.ToString(Array.IndexOf(masOfSum, masOfSum.Min()) + 1);
                }
                return "";
            }
            return "";
        }

        private int dfsS(int u, ref bool[] visited)
        {
            int visitedVertices = 1;
            visited[u] = true;
            for (int i = 0; i < realSize; i++)
                if (!visited[i] && (matr[u].getEl(i) != double.PositiveInfinity || matr[i].getEl(u) != double.PositiveInfinity))
                    visitedVertices += dfsS(i, ref visited);
            return visitedVertices;

        }
        double[] masOfMaxLenth()
        {
            double[][] m = searchOfMinFloid(null);
            if (m != null)
            {
                for (int i = 0; i < realSize; i++)
                    for (int j = 0; j < realSize; j++)
                        if (m[i][j] == double.PositiveInfinity)
                            m[i][j] = 0;

                double[] max = new double[m.Length];
                for (int i = 0; i < m.Length; i++)
                    max[i] = m[i].Max();
                return max;
            }
            return null;
        }
        public String Diametr()
        {
            bool[] vis = new bool[realSize];
            if (dfsS(0, ref vis) == realSize)
            {
                double[] mas = masOfMaxLenth();

                if (mas != null)
                {
                    return "Диаметр: " + mas.Max().ToString();
                }
                return "";
            }
            return "";
        }
        public String Radius()//?
        {
            bool[] vis = new bool[realSize];
            if (dfsS(0, ref vis) == realSize)
            {
                double[] m = masOfMaxLenth();
                if (m != null)
                {
                    for (int i = 0; i < realSize; i++)
                        if (m[i] == 0)
                            m[i] = double.PositiveInfinity;
                    return "Радиус: " + m.Min().ToString();
                }
                return "";
            }
            return "";
        }


        public String Center()
        {
            bool[] vis = new bool[realSize];
            if (dfsS(0, ref vis) == realSize)
            {
                if (masOfMaxLenth() != null)
                {
                    List<int> cenetrs = new List<int>();
                    double[] mas = masOfMaxLenth();
                    for (int i = 0; i < realSize; i++)
                        if (mas[i] == 0)
                            mas[i] = double.PositiveInfinity;
                    double min = mas.Min();
                    for (int i = 0; i < mas.Length; i++)
                        if (mas[i] == min)
                            cenetrs.Add(i + 1);
                    StringBuilder str = new StringBuilder();
                    for (int i = 0; i < cenetrs.Count; i++)
                        str.Append(cenetrs[i] + " ");
                    return "Центр : " + str.ToString();//?

                }
                return "В графе существует отрицательный цикл";
            }
            return "Граф не связный"; ;
        }

        public String minOstovTree()
        {//algorithm Prima, граф обязательно неориентированный и связный!

            for (int i = 0; i < realSize; i++)
                for (int j = 0; j < realSize; j++)
                    if (matr[i].getEl(j) != matr[j].getEl(i))
                        return "Граф ориентированный";
            double[] min_e = new double[realSize];
                for (int i = 0; i < realSize; i++) min_e[i] = double.PositiveInfinity;
                double[] sel_e = new double[realSize];
                for (int i = 0; i < realSize; i++) sel_e[i] = -1;
                min_e[0] = 0;
                bool[] used = new bool[realSize];
                StringBuilder res = new StringBuilder();
                for (int i = 0; i < realSize; ++i)
                {
                    int v = -1;
                    for (int j = 0; j < realSize; ++j)
                        if (!used[j] && (v == -1 || min_e[j] < min_e[v]))
                            v = j;
                    if (min_e[v] == double.PositiveInfinity)
                    {
                        return "Остовного дерева не существует";//error
                    }

                    used[v] = true;
                    if (sel_e[v] != -1)
                        res.Append("|" + (v + 1) + " - " + (sel_e[v] + 1) + "| ");
                    for (int to = 0; to < realSize; ++to)
                        if (matr[v].getEl(to) < min_e[to])
                        {
                            min_e[to] = matr[v].getEl(to);
                            sel_e[to] = v;
                        }
                }
                //  for (int i = 0; i < realSize; i++)
                //res.Append(i.ToString() + "-" + sel_e[i].ToString() + "\n");
                return res.ToString();
            }





            /// <summary>
            /// ////////ПРОВЕРКА НА СВЯЗНОСТЬ
            /// </summary>
            /// <returns></returns>
            /// 
            private void checkAdj()
            {
                if (adjacency != null || adjacency?.getRealSize() != realSize)
                {
                    adjacency = new Adjacency_matr(ref matr, realSize);
                }
            }
            public override string stronglyComponents()
            {
                checkAdj();
                return adjacency.stronglyComponents();
            }

            public override string colorTheGraph()
            {
                checkAdj();
                return adjacency.colorTheGraph();
            }

            public override string humiltonCycle()
            {

                checkAdj();
                return adjacency.humiltonCycle();
            }

            public override string Elrcycel()
            {
                checkAdj();
                return adjacency.Elrcycel();
            }


        }

        struct ver_deg
        {
            public int ver;
            public int deg;
        }
        class Vertex<T>//закрыть класс мод-ми доступа
        {
           private  System.Drawing.Point point;
            public int number { get; set; }//\\
            private T[] compoundWith;

            public ref T[] getCompound()
            {
                return ref compoundWith;
            }
            public T getEl(int n)
            {
                return compoundWith[n];
            }

            

            public void addEl(int n, T data)
            {
                compoundWith[n] = data;
            }

        

        public Vertex(T[] m,int num)
        {
            compoundWith = m;
            number = num;
        }
        public Vertex(T[] m,System.Drawing.Point p,int n)
            {
            point = p;
                compoundWith = m;
                number = n;
                
            }
        public System.Drawing.Point GetPoint() {
            return point;
        }
            public Vertex(int n,int num)
            {
                compoundWith = new T[n];
                number = num;
            }
        }
    }
