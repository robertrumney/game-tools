using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    // Singleton instance for accessing CharacterCreator from other scripts
    public static CharacterCreator instance;

    // CharacterParts contains arrays of Sprites for different character parts
    [System.Serializable]
    public class CharacterParts
    {
        public Sprite[] body;
        public Sprite[] top;
        public Sprite[] bottom;
        public Sprite[] feet;
        public Sprite[] hair;
        public Sprite[] eyes;
        public Sprite[] mouth;
    }

    // References to character parts and the character renderer
    public CharacterParts parts;
    public Character.Renderer creator;

    // Awake method initializes the instance variable
    private void Awake()
    {
        instance = this;
    }

    // Instantiate a new character with a given DNA string
    public Character CreateNewCharacter(string dnaString)
    {
        // Instantiate a new Character prefab (replace with your prefab path)
        GameObject characterPrefab = Resources.Load<GameObject>("CharacterPrefab");
        GameObject characterInstance = Instantiate(characterPrefab);

        // Set up the new character's DNA based on the input string
        Character character = characterInstance.GetComponent<Character>();
        character.dna.Deserialize(dnaString);

        // Render the character based on its DNA
        character.renderer.RenderDNA(character.dna);

        return character;
    }

    // The Character class contains DNA and Renderer classes
    public class Character : MonoBehaviour
    {
        // DNA class stores integer values for each body part
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

            // Deserialize method updates the DNA values based on an input string
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

            // Generates random DNA values based on the available parts
            public void Randomize()
            {
                body = Random.Range(0, instance.parts.body.Length);
                top = Random.Range(0, instance.parts.top.Length);
                bottom = Random.Range(0, instance.parts.bottom.Length);
                feet = Random.Range(0, instance.parts.feet.Length);
                hair = Random.Range(0, instance.parts.hair.Length);
                eyes = Random.Range(0, instance.parts.eyes.Length);
                mouth = Random.Range(0, instance.parts.mouth.Length);
            }
        }

        // Renderer class updates the character's SpriteRenderers based on its DNA
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

            // RenderDNA method updates the character's SpriteRenderers
            public void RenderDNA(DNA dna)
            {
                body.sprite = instance.parts.body[dna.body];
                top.sprite = instance.parts.top[dna.top];
                bottom.sprite = instance.parts.bottom[dna.bottom];
                feet.sprite = instance.parts.feet[dna.feet];
                hair.sprite = instance.parts.hair[dna.hair];
                eyes.sprite = instance.parts.eyes[dna.eyes];
                mouth.sprite = instance.parts.mouth[dna.mouth];
            }
    }

    // Reference to the Character Renderer
    public Renderer renderer;

    // Reference to the Character DNA
    public DNA dna;

    // Start method initializes the character's DNA and Renderer
    private void Start()
    {
        dna = new DNA();
        renderer = GetComponent<Renderer>();
    }

    // Randomize character appearance
    public void RandomizeCharacter()
    {
        dna.Randomize();
        renderer.RenderDNA(dna);
    }
}
