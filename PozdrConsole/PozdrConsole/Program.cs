// See https://aka.ms/new-console-template for more information
using PozdrConsole;

//Console.WriteLine("Hello, World!");
class Program
{
    static void Main()
    {
       
        char character = '\0';

        bool flag = default(bool);

        for (; ; )
        {
            
            Start:
            Console.WriteLine("spisok dney rogdeniya");
            Console.WriteLine("Dlya zapisi novogo polzovatelya vvedite a");
            Console.WriteLine("Dlya ydalenuya polzovatelya vvedite r ");
            Console.WriteLine("Dlya redaktirovaniya polzovatelya vvedite e");
            Console.WriteLine("spisok dney rogdeniya");
            Show();
            Showsoon();
            Showall();
            flag = false;
            character = Console.ReadKey().KeyChar;

            switch (character)
            {
                case 'a': // 'l' - охраняющее условие 1.
                    {
                        Console.WriteLine("dobavlyaem novogo polzovatelya");
                        string p = Console.ReadLine();
                        DateTime date=Convert.ToDateTime(Console.ReadLine());
                        AddBirth(p,date);
                        
                        flag = true; break; // охраняемая команда.
                    }
                case 'r': // 'r' - охраняющее условие 2.
                    {
                        Console.WriteLine("Vvedite nomer polzovatelya dlya ydaleniya");
                        int n = Convert.ToInt32(Console.ReadLine());
                        Remove(n);


                        flag = true; break; // охраняемая команда.
                    }
                case 'e': // 'r' - охраняющее условие 2.
                    {
                        Console.WriteLine("Redaktiruem polzovatelya");
                        Console.WriteLine("Vvedite nomer polzovatelya");
                        int n = Convert.ToInt32(Console.ReadLine());
                        string p = Console.ReadLine();
                        DateTime date = Convert.ToDateTime(Console.ReadLine());
                        Edit(n,p, date);

                        ; flag = true; break; // охраняемая команда.
                    }
            }

            switch (character)
            {
                case 'x': // 'x' - условие выхода 1.
                    {
                        Console.WriteLine("Exit"); goto End; // команда завершения.
                    }
                case 'q': // 'q' - условие выхода 2.
                    {
                        Console.WriteLine("Quit"); goto End; // команда завершения.
                    }
            }

            // Ветвь альтернативного завершения.
            if (flag==true)
            {
                goto Start;
            }

            Console.WriteLine("Alternative exit");

            End:
            break;  // Прерывание цикла.
        }

        // Delay.
        Console.ReadKey();

    }




    static void Show()
    {
        using (BirthContext db = new BirthContext())
        {

            var users = db.Models.Where(x => x.Date == DateTime.Today).ToList();
            Console.WriteLine("----------------");
            Console.WriteLine("Dr segodnya y:");
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);

            }


        }

    }
    static void Showall()
    {
        using (BirthContext db = new BirthContext())
        {

            var users = db.Models.ToList();
            Console.WriteLine("----------------");
            Console.WriteLine("Ves spisok ludey:");
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);

            }


        }

    }

    static void AddBirth( string p, DateTime date)
    {
        using (BirthContext db = new BirthContext())
        {
            Model user1 = new Model { Name = p, Date = date };
           

            // Добавление
            db.Models.Add(user1);
            
            db.SaveChanges();
        }


    }
    static void Remove( int id)
    {
        using (BirthContext db = new BirthContext())
        {
           
            Model model=db.Models.First(x => x.Id == id);

            if (model != null)
            {

                db.Models.Remove(model);
                db.SaveChanges();
            }

            else
            {
                Console.WriteLine("takogo nety");
            }

            
        }


    }
    static void Edit(int id, string p, DateTime date)
    {
        using (BirthContext db = new BirthContext())
        {

            Model model = db.Models.First(x => x.Id == id);

            if (model != null)
            { 
                 model=new Model { Name = p, Date = date };

                db.Models.Update(model);
                db.SaveChanges();
            }

            else
            {
                Console.WriteLine("takogo nety");
            }


        }


    }
    static void Showsoon()
    {
        using (BirthContext db = new BirthContext())
        {

            var users = db.Models.Where(x => x.Date == DateTime.Today.AddDays(1)).ToList();
            Console.WriteLine("----------------");
            Console.WriteLine("Dr sovsem skoro y:");
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);

            }
            var userss = db.Models.Where(x => x.Date == DateTime.Today.AddDays(2)).ToList();
            Console.WriteLine("Dr  skoro y:");
            foreach (var user in userss)
            {
                Console.WriteLine(user.Name);

            }



        }
    }

}

