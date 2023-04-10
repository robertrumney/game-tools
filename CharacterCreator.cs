using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    public static CharacterCreator instance;

    public CharacterParts parts;
    public Character.Renderer creator;

    [System.Serializable]
    public class CharacterParts
    {
        public Sprite[] body;
        public Sprite[] top;
        public Sprite[] bottom;
        public Sprite[] feet;
        public Sprite[] hair;
        public Sprite[] eyes;
    }

    public class Character : MonoBehaviour
    {
        [System.Serializable]
        public class DNA
        {
            public int body;
            public int top;
            public int bottom;
            public int feet;
            public int hair;
            public int eyes;
            public int mouth;

            public void Deserialize(string s)
            {
                string[] _s = s.Split("/"[0]);
                body = int.Parse(_s[0]);
                top = int.Parse(_s[1]);
                bottom = int.Parse(_s[2]);
                feet = int.Parse(_s[3]);
                hair = int.Parse(_s[4]);
                eyes = int.Parse(_s[5]);
                mouth = int.Parse(_s[6]);
            }
        }

        [System.Serializable]
        public class Renderer
        {
            public SpriteRenderer body;
            public SpriteRenderer top;
            public SpriteRenderer bottom;
            public SpriteRenderer feet;
            public SpriteRenderer hair;
            public SpriteRenderer eyes;
            public SpriteRenderer mouth;

            public void RenderDNA(DNA dna)
            {
                body.sprite = instance.parts.body[dna.body];
                top.sprite = instance.parts.body[dna.top];
                bottom.sprite = instance.parts.body[dna.bottom];
                feet.sprite = instance.parts.body[dna.feet];
                hair.sprite = instance.parts.body[dna.hair];
                eyes.sprite = instance.parts.body[dna.eyes];
                mouth.sprite = instance.parts.body[dna.mouth];
            }
        }

        public Renderer human;
    }

    private void Awake()
    {
        instance = this;
    }
}
