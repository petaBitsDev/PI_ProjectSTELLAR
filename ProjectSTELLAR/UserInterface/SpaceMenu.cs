using ProjectStellar.Library;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    public class SpaceMenu
    {
        Game _ctx;
        bool[] _tabState = new bool[4];
        List<SpaceMenu> _list = new List<SpaceMenu>();
        Building _spaceStation;
        RectangleShape[] _availabilities = new RectangleShape[4];
        RectangleShape[] _tabs = new RectangleShape[4];
        RectangleShape _rec;
        Text[] _texts = new Text[4];
        Sprite _send;
        Sprite _sendActive;
        Font _font;
        bool _isOn;
        Sprite _redCross;

        public SpaceMenu(Game ctx, Building building)
        {
            _ctx = ctx;
            _spaceStation = building;
            _font = _ctx._font;
            _isOn = false;

            _send = new Sprite(_ctx._uiTextures[24]);
            _sendActive = new Sprite(_ctx._uiTextures[25]);
            _redCross = new Sprite(_ctx._uiTextures[22]);

            _rec = new RectangleShape();
            _rec.Size = new Vector2f(32 * 12, 32 * 6);
            _rec.FillColor = new Color(30, 30, 40);

            RectangleShape tab = new RectangleShape();
            tab.Size = new Vector2f(32 * 3, 32);
            _tabs[0] = tab;
            RectangleShape tab1 = new RectangleShape();
            tab1.Size = new Vector2f(32 * 3, 32);
            _tabs[1] = tab1;
            RectangleShape tab2 = new RectangleShape();
            tab2.Size = new Vector2f(32 * 3, 32);
            _tabs[2] = tab2;
            RectangleShape tab3 = new RectangleShape();
            tab3.Size = new Vector2f(32 * 3, 32);
            _tabs[3] = tab3;

            _tabState[0] = true;
            _tabState[1] = false;
            _tabState[2] = false;
            _tabState[3] = false;

            Text s = new Text("Ship 1", _font);
            s.CharacterSize = 20;
            s.Color = new Color(30, 30, 40);
            _texts[0] = s;
            Text s1 = new Text("Ship 2", _font);
            s1.CharacterSize = 20;
            s1.Color = new Color(30, 30, 40);
            _texts[1] = s1;
            Text s2 = new Text("Ship 3", _font);
            s2.CharacterSize = 20;
            s2.Color = new Color(30, 30, 40);
            _texts[2] = s2;
            Text s3 = new Text("Ship 4", _font);
            s3.CharacterSize = 20;
            s3.Color = new Color(30, 30, 40);
            _texts[3] = s3;

            RectangleShape availability = new RectangleShape();
            availability.Size = new Vector2f(64, 12);
            _availabilities[0] = availability;
            RectangleShape availability1 = new RectangleShape();
            availability1.Size = new Vector2f(64, 12);
            _availabilities[1] = availability1;
            RectangleShape availability2 = new RectangleShape();
            availability2.Size = new Vector2f(64, 12);
            _availabilities[2] = availability2;
            RectangleShape availability3 = new RectangleShape();
            availability3.Size = new Vector2f(64, 12);
            _availabilities[3] = availability3;
        }

        public RectangleShape Rec => _rec;

        public bool[] TabState
        {
            get { return _tabState; }
            set { _tabState = value; }
        }

        public Text[] Texts
        {
            get { return _texts; }
        }

        public Sprite RedCross => _redCross;
        public RectangleShape[] Availabilities
        {
            get { return _availabilities; }
        }

        public RectangleShape[] Tabs
        {
            get { return _tabs; }
        }

        public Sprite SendSprite
        {
            get { return _send; }
        }

        public Sprite SendSpriteActive
        {
            get { return _sendActive; }
        }
        public List<SpaceMenu> List
        {
            get { return _list; }
            set { _list = value; }
        }

        public Building SpaceStation
        {
            get { return _spaceStation; }
            set { _spaceStation = value; }
        }

        public bool IsOn
        {
            get { return _isOn; }
            set { _isOn = value; }
        }
    }
}
