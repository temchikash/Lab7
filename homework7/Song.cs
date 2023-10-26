using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework7
{
    internal class Song
    {
        private string name;
        private string author;
        public Song prev;
        public void SongName()
        {
            Console.WriteLine("Введите название песни :");
            name = Console.ReadLine();
            Console.WriteLine("Песня добавлена");
        }
        public void SongAuthor()
        {
            Console.WriteLine("Введите автора песни :");
            author = Console.ReadLine();
            Console.WriteLine("Автор добавлен");
        }
        public void Previous(List<Song> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].SongName();
                list[i].SongAuthor();
                if (i != 0)
                {
                    list[i].prev = list[i - 1];
                }
                else
                {
                    Console.WriteLine("Предыдущей песни нет - это первая в списке\n");
                }
                list[i].Print();
                
            }
        }
        public string Print()
        {
            string information = name + "" + author;
            return information;
        }
        public override bool Equals(object obj)
        {
            Song song = obj as Song;
            if (song!= null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
