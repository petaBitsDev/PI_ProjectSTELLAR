using SFML.Audio;

namespace ProjectStellar
{
    public class SoundManager
    {
        readonly string _path;
        Music _music;
        readonly Sound[] _sounds;


        public SoundManager()
        {
            _path = "./resources/sounds/";
            _sounds = new Sound[2];
        }

        public void LoadSounds()
        {
            _music = new Music(_path + "YouthfulIllusions.ogg");
            _sounds[0] = new Sound(new SoundBuffer(_path + "build.ogg"));
            _sounds[0].Volume = 50;
            _sounds[1] = new Sound(new SoundBuffer(_path + "destroy.ogg"));
            _sounds[1].Volume = 50;
        }

        public void StartMusic()
        {
            _music.Loop = true;
            _music.Volume = 50;
            _music.Play();
        }

        public float MusicVolume
        {
            get { return _music.Volume; }
            set
            {
                if (value < 0)
                    _music.Volume = 0;
                else if (value > 100)
                    _music.Volume = 100;
                else
                    _music.Volume = value;
            }
        }

        public float SFXVolume
        {
            get { return _sounds[0].Volume; }
            set
            {
                for (int i = 0; i < _sounds.Length; i++)
                {
                    if (value < 0)
                        _sounds[i].Volume = 0;
                    else if (value > 100)
                        _sounds[i].Volume = 100;
                    else
                        _sounds[i].Volume = value;
                }
            }
        }

        

        public Sound Build => _sounds[0];
        public Sound Destroy => _sounds[1];
    }
}
