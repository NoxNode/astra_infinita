using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System.IO;

namespace astra_infinita {
    class MusicPlayer
    {
       public Song current_song;
        public string current_song_path;

        public Dictionary<Song,String> song_list;
        public MusicPlayer()
        {
            song_list = new Dictionary<Song, string>();
            current_song = null;
            current_song_path = "";
        }
        /// <summary>
        /// Plays a song inside of the Content folder that is located at the string s.
        /// </summary>
        /// <param name="s">The path inside the Content folder to the music file.</param>

        public virtual void play_song(String s)
        {
            try {
                current_song = Game1.content.Load<Song>(s);
                current_song_path = s;
                MediaPlayer.Play(current_song);
            }
            catch(Exception e) //file not found
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Looks for a song specified in the Song List. The s passed is the song's name.
        /// </summary>
        /// <param name="s">The song's name</param>
        public virtual void play_song_from_list(String s)
        {
            foreach(KeyValuePair<Song,string> pair in song_list)
            {
                if (pair.Key.Name == s)
                {
                    current_song = pair.Key;
                    current_song_path = pair.Value;
                    break;
                }
            }
            MediaPlayer.Play(current_song);
        }

        public virtual void AddSong(String s)
        {
            Song new_song = Game1.content.Load<Song>(s);
            song_list.Add(new_song, s);
        }

        public virtual void play_random_song()
        {
            Random r = new Random();
            int random = r.Next(0, song_list.Count);
            current_song = song_list.Keys.ElementAt(random);
            current_song_path = song_list.Values.ElementAt(random);
            Console.WriteLine(current_song);
            Console.WriteLine(current_song_path);
            MediaPlayer.Play(current_song);
        }

        public virtual void stop_song()
        {
            MediaPlayer.Stop();
        }
        public virtual void pause_song()
        {
            MediaPlayer.Pause();
        }
        public virtual void resume_song()
        {
            MediaPlayer.Resume();
        }
        public virtual void Update(GameTime gameTime)
        {

            //Console.WriteLine(MediaPlayer.State);
            if (MediaPlayer.State == MediaState.Stopped)
            {
                play_random_song();
               
            }
        }

        public virtual void Load()
        {
            AddSong(Path.Combine("Music", "Songs", "Wasteland", "Wasteland1"));
        }
    }
}
