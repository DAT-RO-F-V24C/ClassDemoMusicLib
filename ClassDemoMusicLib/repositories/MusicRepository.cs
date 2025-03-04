using ClassDemoMusicLib.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoMusicLib.repositories
{
    public class MusicRepository
    {
        // instance fields
        private readonly List<Music> _musics;

        // constructor
        public MusicRepository(bool mockData = false)
        {
            _musics = new List<Music>();

            if (mockData)
            {
                _musics.Add(new Music(1, "Live and let die", 1973));
                _musics.Add(new Music(2, "Skyfall", 2012));
                _musics.Add(new Music(3, "Goldfinger", 1964));
            }
        }


        /*
         * CRUD operations
         */
        public List<Music> GetAll()
        {
            return new List<Music>(_musics);
        }

        public Music GetById(int id)
        {
            Music? Music = _musics.Find(m => m.Id == id);
            if (Music == null)
            {
                throw new KeyNotFoundException();
            }
            return Music;
        }
        public Music Add(Music music)
        {
            music.Id = GenerateId();
            _musics.Add(music);
            return music;
        }
        public Music Delete(int id)
        {
            Music music = GetById(id);
            _musics.Remove(music);
            return music;
        }
        public Music Update(int id, Music updatedMusic)
        {
            Music music = GetById(id);
            int ix = _musics.IndexOf(music);
            _musics[ix] = updatedMusic;
            return updatedMusic;
        }

        public List<Music> Search(int? fromYear, int? toYear)
        {
            List<Music> liste = new List<Music>(_musics);

            if (fromYear is not null)
            {
                liste = liste.Where(m => m.Year >= fromYear).ToList();
            }

            if (toYear is not null)
            {
                liste = liste.Where(m => m.Year <= toYear).ToList();
            }

            return liste;
        }

        // help function
        private int GenerateId()
        {
            return (_musics.Count == 0) ? 1 : _musics.Max(a => a.Id) + 1;
        }
    }
}
