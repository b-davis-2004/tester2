//refer to snake enemies code for proper set up
//conflicts for everything but snakes need to be added
//all other variables need to be defined according to story
//in program.cs consquences for run need to be added
//consquences for conflict and negotiate are defined with trigger, just need story plot
//CODE IS FUNCTIONING AND TESTED
//TEST AGAIN AFTER ALTERATIONS FOR STORY

public class Enemy
{
    public string Name { get; set; }
    public string AttackStyle { get; set; }
    public string Conflict { get; set; }
    public string conflictResponse1 {get; set;}
    public string conflictResponse2 {get; set;}
    public string Placate {get; set;}



    public Enemy(string name, string attackStyle, string conflict, string conflictR1, string conflictR2, string placate)
    {
        Name = name;
        AttackStyle = attackStyle;
        Conflict = conflict;
        conflictResponse1 = conflictR1;
        conflictResponse2 = conflictR2;
        Placate = placate;
    }
}
public static class EnemyLibrary
{
    //Alter so conflict coorleates with three user options
    public static Enemy Bandit => new("Bandits", "The leader of the group approaches you with a sword in one hand and a machete in the other. The others watch menacingly and wait for orders to attack",
        "The bandits lunge with their blades.", "You drop to the ground and roll, dogging their attack. \nDrawing your own blade, you slash at the heels of the leader, watching as he crumples to his knees. \nThe bandits rush to help their own and you take this time to flee.",
        "The bandits chase and outnumber you. \nYou're struck down before you can even get out of sight of the camp.",
        "You raise your hands up in a display of non-aggression. \n You cry out that you don not want any trouble and offer any gold on your person in trade for safe passage past the camp.");
    public static Enemy Troll => new("A Troll", " The troll draws heavy wooden club, he insists you must pay him before you are allowed to cross.",  "You refuse to pay the toll, threatening you will cross even if it means you have to go through the Troll.",
        "You size up the Troll. \nHe is strong but you are fast. He swings his club. \nYou duck beneath it, evading the strike. \nWith this opening, you rush forward and slide between it's legs. \nIn one sweep, you use his size against him, knocking him in the backs of the knees and sending him crashing down. \nThe bridge gives out under his weigh, sending the Troll beneath into the river, allowing you to pass.",
        "Your courage falters and you begin to back away. \nThe Troll does not take your disrespect lightly. \nWith one swing of his club, he knocks you clear off the bridge and into the rapid water.",
        "You explain to the troll you woke up here with limited supplies. \n The few coins on your person cannot be spared to cross the river and beg for passage.");
    public static Enemy Assassin => new(" An Assassin", "The assassin unsheathes his sword and challenges you to a duel for invading his territory.",  "You accept his challenge, taking out your own blade.",
        "You lunge at the assassin. \nYour blades clash in a whirlwind of spark and screetches. \nYou fight until your muscles ache and the blade is too heacy to hold. \nCollapsing to your knees, you look up at your enemy. \nBut he doesn't strike you down... \nInstead he compliments your fight and disappears off back into the caverns, a quiet mercy from one adventurer to another.",
        "Unmatched for the Assassin's speed, your stall allows the Assissin to drive the sword through you in one clean motion.", 
        "You attempt to tell the Assassin that you do not want to fight and did not know this land was part of his territory. You ask for mercy.");
    public static Enemy Thief => new("A Thief", "The stranger they pull out a small blade and demand you empty your pockets!",  "Slowly, you draw you blade and raise it before you in an offensive stance.",
        "Before the theif can react, you lunge forward and blindly slash at the enemy. \nHe falls the ground, gripping his slashed hand. \nYou take this time to escape while he is down.",
        "Your sudden movements startles the Thief. \nHe lashes out, striking you in the stomach with his small blade.", 
        "You introduce yourself by name, careful to move slow as not to startle the theif. You explain you are not from here and have no money to spare. You turn you pockets out, in emphasis.");
    public static Enemy Witch => new("Witches", "Their cackles can be heard, drawing nearer with obvious nefarious intent.",  
        "The witches will hex you unless you defeat them, whispering their incantations like a audible poison.",
        "You rush to one of the shelves, blindly grabbing vials and throwing them at the witches. \nExplosions boom and smoke fills the room, accompanied by the screams of the Coven. \nYou take this moment of panic to flee.", 
        "The witches whispers grow louder as you turn on your heel. \nSuddenly, an invisible weigh presses down on you and you collapse to the ground. \nYou can feel your heart slowing, every beat becoming sluggish until you pass out and it quits beating all together.",
        "The sight of the blasphamous, demonic creatures sent you to your hands and knees. Against their chants your prayed for both their mercy and God's.}");
    public static Enemy Snake => new("A Snake", "It draws its head up, hissing and baring its fangs.",  "The snake strikes! Its venomous fangs lashing for your leg.",
        "Your reflexes beat the snake's. Gripping it's neck, you cut off it's head and defeat it.",
        "The snake pursues, latching onto your leg and piercing your leg with it's fangs. \nIt's venom quickly circulating through your blood.",
        "You pull a 'Lucy Gray Ballard' and attempt to sing to the snake to placate it.");
    public static Enemy Fish => new("A Fish", "It swims along unassumingly, scales shimmering against the sunlight in the crystal clear water.", 
        "You catch sight of the silvery flash of scales beneath the ripples of water at your feet. \nYou draw your blade and attempt to catch yourself a meal.",
        "You thrust your blade into the water, neatly piercing the fish's side. \nWith you catch, you proceed to build a fire and enjoy your hard earned meal.",
        "You trip into the River. \nRealizing you cannot swim, your head dips below the water and your lungs fill with water.", 
        "You wade into the water and dunk your head beneath, holding your hands out to the creature, urging it almost pointlessly to swim into your grasp.");
    public static Enemy Hog => new("A Hog", "It postures, displaying its tusks menacingly.",  "The beast charges. You look around, deciding if it was better to take the beast head on or evade.",
        "You plant your feet and grab the hog by its tusks as it collides with you. \nYour hands burn but you don't let go. With a forceful shove, you redirect the hog to the side. \nIt huffs but backs away, conceding and disappearing to scavange the farmland.",
        "You waited too long to run. \nThe Hog pursues, its tusks shredding through your legs.", 
        "You make yourself small, attempting to seem non-threatening to the wild animal, staying dead silent.");
    public static Enemy Moose => new("A Moose", "The moose doesn't seem to notice you, this is the perfect opportunity to get some much needed food. You draw your bow and arrow.",
        "Noticing your movements, it stamps it's hoof - preparing to charge.", "Loosing your arrow, your aim is true and you pierce the beasts heart. \nUsing it's meat, you settle and have a much needed meal.",
        "Enraged by your offensive stance, it follows. \nThe sound of its hoofs growing closer from behind in pursuit. \nThe moose collides with your back, knocking you down and trampling you.", 
        "Knowing the moose was too big to take down, you wait and watch. Silently stalking in hopes it would lead you to a smaller prey to hunt to fill your rumbling stomach.");
      
}