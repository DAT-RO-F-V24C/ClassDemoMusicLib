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
        public MusicRepository()
        {
            _musics = new List<Music>();
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

        // help function
        private int GenerateId()
        {
            return (_musics.Count == 0) ? 1 : _musics.Max(a => a.Id) + 1;
        }
    }
}
