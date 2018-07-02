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
            _sounds[1] = new Sound(new SoundBuffer(_path + "destroy.ogg"));
        }

        public void StartMusic()
        {
            _music.Loop = true;
            _music.Volume = 50;
            _music.Play();
        }

        public Sound Build => _sounds[0];
        public Sound Destroy => _sounds[1];
    }
}
