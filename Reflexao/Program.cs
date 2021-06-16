using System;
using System.Reflection;
using System.Text;

namespace Reflexao
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(Carro);

            GetParametros(t);

            GetInterfaces(t);

            GetPropriedades(t);

            GetCampos(t);

            GetMetodo(t);

            GetMetodos(t);

            GetInfo(t);


            Typeof();

            TypeStringClass();

            TypeClass();

            Console.ReadLine();
        }

        private static void GetParametros(Type t)
        {
            Console.WriteLine("Parâmetros:");
            MethodInfo[] mi = t.GetMethods();
            foreach (var m in mi)
            {
                string resultado = m.ReturnType.FullName;
                Console.WriteLine(Environment.NewLine + m.Name);
                Console.WriteLine(resultado);
                StringBuilder str = new StringBuilder();
                foreach (ParameterInfo pi in m.GetParameters())
                {
                    str.AppendLine($"Params: {pi.ParameterType}, {pi.Name}");
                }

                Console.WriteLine(str);
            }
        }

        private static void GetInterfaces(Type t)
        {
            Console.WriteLine("Interfaces:");
            Type[] intf = t.GetInterfaces();
            foreach (var i in intf)
                Console.WriteLine(i.Name);
        }

        private static void GetCampos(Type t)
        {
            Console.WriteLine("Campos:");
            FieldInfo[] fi = t.GetFields();
            foreach (var f in fi)
                Console.WriteLine(f.Name);
        }

        private static void GetPropriedades(Type t)
        {
            Console.WriteLine("Propriedades:");
            PropertyInfo[] pi = t.GetProperties();
            foreach (var p in pi)
                Console.WriteLine(p.Name);
        }

        private static void GetMetodo(Type t)
        {
            MethodInfo mi = t.GetMethod("EstaMovendo");
            Console.WriteLine(mi.Name);
        }

        private static void GetMetodos(Type t)
        {
            Console.WriteLine("Métodos:");
            // MethodInfo, classe utlizada para especificar métodos
            // BindingFlags, especificar sinalizadores que controlam a ligação e maneira na qual a pesquisa por tipos
            //e membros é realizada por reflexão
            // Por exemplo, DeclaredOnly: 2 . Especifica que somente os membros declarados no nível da hierarquia do
            //tipo fornecido devem ser considerados. Membros herdados não são considerados.
            MethodInfo[] mi = t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            //MethodInfo[] mi = t.GetMethods();
            foreach (var m in mi)
                Console.WriteLine($"Método: {m.Name}");
        }

        private static void GetInfo(Type t)
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine($"Informações do tipo: {t.Name}");
            str.AppendLine($"Nome completo: {t.FullName}");
            str.AppendLine($"Namespace: {t.Name}");

            Type tBase = t.BaseType;
            if (tBase != null)
            {
                str.AppendLine($"Tipo base: {t.BaseType.Name}");
            }

            // MemberInfo, classe utlizada para especificar propriedades e métodos
            MemberInfo[] membros = t.GetMembers();
            foreach(var m in membros)
            {
                str.AppendLine(m.MemberType + " " + m.Name);
            }

            Console.WriteLine(str);
        }

        // Utilizando typeof para Reflexão
        private static void Typeof()
        {
            Type t = typeof(Carro);
            Console.WriteLine(t.FullName);
        }

        // Utilizando a Classe Type com string para Reflexão
        private static void TypeStringClass()
        {
            Type t = Type.GetType("Reflexao.Carro", false, true);
            Console.WriteLine(t.FullName);
        }

        // Utilizando a Classe Type para Reflexão
        private static void TypeClass()
        {
            Carro c = new Carro();
            Type t = c.GetType();
            Console.WriteLine(t.FullName);
        }
    }
}
