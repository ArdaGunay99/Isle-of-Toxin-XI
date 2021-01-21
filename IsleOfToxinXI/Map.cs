using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace IsleOfToxinXI
{
    public class Map
    {
        private Form1 _form1 = (Form1) Application.OpenForms["Form1"];
        private static Map _map = new Map();//Singleton

        private Map()
        {
            
        }
        public static Map getInstance()
        {
            return _map;
        }
        public void StartPoint(Character player)
        {
            _form1.ResetButtons();
            _form1.AddLine(">You have opened your parachute and flew to the previously designated arrival location.\r\n" +
                           ">it is an open area and there seems to be no threat nearby. you look around and you see three ways that you can choose:\r\n" +
                           ">North,South and west. Press to choose your way: ");
            _form1.ChangeB1Text("North");
            _form1.ChangeB2Text("South");
            _form1.ChangeB3Text("West");
            _form1.EnableButtons();
            Form1.Wait.WaitOne();
            Debug.WriteLine("wait ended in start point");

            if(_form1.B1Clicked)
            { 
                fromStartToForest(player);
            }
            else if(_form1.B2Clicked )
            { 
                fromStartToDesert(player);
            }
            else if(_form1.B3Clicked)
                fromStartToTown1(player);
        }

    public void fromStartToTown1(Character player)
    {
        _form1.ClearText();

        _form1.ResetButtons();
        _form1.AddLine(">Now you are on a road with huge rocks on both sides that directs you to" +
                                "\r\n>somewhere.It's obviously made by some kind of civilization"+
                                "\r\n>While you are walking you saw a aloe vera plant" +
                                "\r\n >which can be used as medicine(it adds 25 health automatically)\r\n" +
                                ">Press to take it or leave it:");
         _form1.EnableButtons();
         _form1.ChangeB1Text("Take");
         _form1.ChangeB2Text("Leave");
         _form1.DisableB3();
         Form1.Wait.WaitOne();
        if(_form1.B1Clicked)
        {
            player.setHealth(player.getHealth()+25);
            if(player.getHealth()>=100)
                player.setHealth(100);
            _form1.SetHealthBar((int)player.getHealth());
           _form1.AddLine(">Aloe vera taken. New health point : "+ player.getHealth());
        }
        else if (_form1.B2Clicked)
        {
            _form1.AddLine("> You left the aloe vera plant.");
        }
        _form1.ResetButtons();
        Creature newCreature = new Feline("Catimo",true,5,1,1,1,1);//runtime polymorphism
        _form1.AddLine(">You continue to walk along the road and suddenly encounter some kind of animal which resambles a feline\r\n" +
                ">You look at the database and learn that it's a "+newCreature.GetCreatureName()+" and it is hostile and coming to attack you!\r\n" +
                ">press to counter attack or to dodge and run: ");
        _form1.EnableButtons();
        _form1.ChangeB1Text("Attack");
        _form1.ChangeB2Text("Dodge");
        _form1.DisableB3();
        Form1.Wait.WaitOne();
        if(_form1.B1Clicked)
        {
            player.Fight(player,newCreature);
        }
        else if(_form1.B2Clicked)
        {
            player.Escape(player,newCreature);
        }
        _form1.ResetButtons();
        _form1.AddLine(">Now you are at the end of the road. There seems to be a abandoned human resident.\r\n" +
                       " Press to go in or to turn back:  ");
        _form1.EnableButtons();
        _form1.ChangeB1Text("Go In");
        _form1.ChangeB2Text("Return");
        _form1.DisableB3();
        Form1.Wait.WaitOne();
        if(_form1.B1Clicked)
        {
            Town1(player);
        }
        else if(_form1.B2Clicked)
            StartPoint(player);

    }

    public void Town1(Character player)
    {
        _form1.ClearText();

        _form1.ResetButtons();
        Item newItem = new Item("Machete",15,50);
        Creature newCreature = new Crazy("Humanoid",true,5,2,2,2,2);//runtime polymorphism
        
        _form1.AddLine(">You have entered what seems to be a human resident.\n" +
                ">There are tents which some of are burned down or torn apart.\n" +
                ">You see something shining in one of the tents. You go look inside and you see a "+newItem.ItemName);
        _form1.AddLine(newItem.printInfo());
        _form1.AddLine("Press to take it or to leave it:");
        
        _form1.EnableButtons();
        _form1.ChangeB1Text("Take");
        _form1.ChangeB2Text("Leave");
        _form1.DisableB3();
        Form1.Wait.WaitOne();
       
        if(_form1.B1Clicked)
        {
           _form1.AddLine(player.addToCharInventory(newItem));
        }
        else if (_form1.B2Clicked)
        {
            _form1.AddLine("> You left the "+newItem.ItemName);
        }
        _form1.ResetButtons();
       
        _form1.AddLine(">You go out in the open again and just as you were leaving you here a battle cry coming from behind you.\r\n" +
                ">You turn around and see a human which has been effected by the toxin.\r\n" +
                ">It quite resembles a zombie but it is really fast and it's going to attack you! Press fight or escape:");
        
        _form1.EnableButtons();
        _form1.ChangeB1Text("Fight");
        _form1.ChangeB2Text("Escape");
        _form1.DisableB3();
        Form1.Wait.WaitOne();
        
        if(_form1.B1Clicked)
        {
            player.Fight(player,newCreature);
        }

        else if(_form1.B2Clicked)
        {
            player.Escape(player,newCreature);
        }
        _form1.ResetButtons();
        _form1.AddLine("There seems to be a path leading into another human resident.\r\n" +
                "Press to continue from this road or to go back: " );
        
        _form1.EnableButtons();
        _form1.ChangeB1Text("Continue");
        _form1.ChangeB2Text("Go Back");
        _form1.DisableB3();
        Form1.Wait.WaitOne();
        
        if (_form1.B1Clicked)
            Town3(player);
        
        else if(_form1.B2Clicked)
            fromStartToTown1(player);
    }

    public void Town3(Character player)
    {
        _form1.ClearText();

        _form1.ResetButtons();
        NPC newNPC = new NPC("Jack");
        Item newItem = new Item("Metal rod",5,15);
        Item newItem1 = new Item("knife",5,15);
        Creature newCreature = new Bird("Stinger",true,15,3,3,1,3);//runtime polymorphism
        newNPC.addToNPCInventory(newItem);
        
        _form1.AddLine(">Walking on the the road, you see your colleague "+newNPC.getNPCName()+
                "\r\n>He is on the ground and bleeding! He sees you and Calls you with your name: Semiramis." +
                "\r\n>You go near him and see that he has lost a leg and stabbed through the stomach.\r\n" +
                ">he says that there is nothing to do and that he is going to die soon.\r\n" +
                ">Before he dies he says that you can take his rod and use it to combine it with his knife.\r\n" +
                ">Press to accept the trade or to refuse:");
        
        _form1.EnableButtons();
        _form1.ChangeB1Text("Accept");
        _form1.ChangeB2Text("Refuse");
        _form1.DisableB3();
        Form1.Wait.WaitOne();
        
        if(_form1.B1Clicked)
        {
            newNPC.trade(newNPC, player, newItem);
            player.getCharInventory().craft(newItem,newItem1,"Spear");
        }
        else if (_form1.B2Clicked)
        {
            _form1.AddLine(">You refused the trade and watched him as he faded away.");
        }
        _form1.ResetButtons();
        
        _form1.AddLine(">You go into the resident and look around for Jack's murderer. Then you hear a screech form above.\r\n" +
                ">You look up and see that a giant "+ newCreature.GetCreatureName()+" is coming for you. This giant wasp is probably Jack's killer.\r\n" +
                ">Press attack or escape:");
        _form1.EnableButtons();
        _form1.ChangeB1Text("Attack");
        _form1.ChangeB2Text("Escape");
        _form1.DisableB3();
        Form1.Wait.WaitOne();
        if (_form1.B1Clicked)
        {
            player.Fight(player,newCreature);
        }
        else if(_form1.B2Clicked)
            player.Escape(player,newCreature);
        _form1.ResetButtons();
        _form1.AddLine(">you now have two roads in front of you\r\n" +
                " press to go to the mountains or to go to another human resident or to return: ");
       
        _form1.EnableButtons();
        _form1.ChangeB1Text("Mountains");
        _form1.ChangeB2Text("Resident");
        _form1.ChangeB3Text("Return");
        Form1.Wait.WaitOne();
        
        if (_form1.B1Clicked)
        { 
            mountain(player);
        }
        else if(_form1.B2Clicked)
        {
            // Town2(player);
        }
        else if(_form1.B3Clicked)
        {
            Town1(player);
        }
    }
    public void fromStartToForest(Character player)
    {
        _form1.ResetButtons();
        _form1.ClearText();
        
        _form1.AddLine("This side of map is unavailable returning to last location...");
        StartPoint(player);
    }
    public void fromStartToDesert(Character player)
    {
        _form1.ResetButtons();
        _form1.ClearText();
          
        _form1.AddLine("This side of map is unavailable returning to last location...");
        StartPoint(player);
    
    }
    public void forest(Character player)
    {
        _form1.ResetButtons();
        _form1.ClearText();
          
        _form1.AddLine("This side of map is unavailable returning to last location...");
        StartPoint(player);
    }
    public void desert(Character player)
    {
        _form1.ResetButtons();
        _form1.ClearText();
          
        _form1.AddLine("This side of map is unavailable returning to last location...");
        StartPoint(player);
    }
    public void seaSide(Character player)
    {
        _form1.ResetButtons();
        _form1.ClearText();
          
        _form1.AddLine("This side of map is unavailable returning to last location...");
        desert(player);
    }
    public void mountain(Character player)
    {
        _form1.ResetButtons();
        _form1.ClearText();       
      
        Item newItem=new Item ("rotten Axe",11 ,80 );
        Creature newCreature = new Crazy("The Dead",true,25,3,3,4,2);//runtime polymorphism
        _form1.AddLine(">Nobody knows why but you are now on the top of the mountain.Thanks to the snowy storm your line of sight is pretty limited.\r\n"+
                "The only thing that you can feel is an immense cold.You wander around pointlessly.By the time you are about to loose your hopes you slightly see a small cottage right in the woods.\r\n "
                +"You get in the cottage and among all the old stuff in the cottage 2 things get your attention. A body seems to be dead and a rotten axe.");
        newItem.printInfo();
       
        _form1.AddLine("Press to take the rotten axe or to leave it:");
        _form1.EnableButtons();
        _form1.ChangeB1Text("Take");
        _form1.ChangeB2Text("Leave");
        _form1.DisableB3();
        Form1.Wait.WaitOne();
        
        if(_form1.B1Clicked)
        {
            player.setHealth(player.getHealth()-4);
            if(player.getHealth()<=0)
            {
                player.setHealth(0);
                player.playerDead();
                return;
            }
            _form1.SetHealthBar((int)player.getHealth());
            player.addToCharInventory(newItem);
            _form1.AddLine(">You kneel down to get the rotten axe.As soon as you start standing back up you see something running towards you.It catches you unbalanced.\r\n"+
                    ">It hits you once and you lose 4 health points.Now your health is: "+player.getHealth()+"The dead body is after \r\n");
        }
        else if(_form1.B2Clicked)
        {
            _form1.AddLine(">You have left the "+newItem.ItemName);
            _form1.AddLine(">You see the dead body slowly getting up.It seems to not like you.");
        }
        _form1.ResetButtons();
        
        _form1.AddLine(">It is"+ newCreature.GetCreatureName() +"Press  to fight or to escape.");
        _form1.EnableButtons();
        _form1.ChangeB1Text("Fight");
        _form1.ChangeB2Text("Escape");
        _form1.DisableB3();
        Form1.Wait.WaitOne();
        
        if(_form1.B1Clicked) {
            player.Fight(player, newCreature);
        }
        else if(_form1.B2Clicked)
        {
            player.Escape(player, newCreature);
        }
        _form1.ResetButtons();
        _form1.AddLine(">You immediately leave the cottage.You find a high spot where you can see things more clearly\r\n"+
                ">You see a swamp in the distance leading to a pond.Press to go to the pond or to get back to the town.");
        _form1.EnableButtons();
        _form1.ChangeB1Text("Pond");
        _form1.ChangeB2Text("Town");
        _form1.DisableB3();
        Form1.Wait.WaitOne();
        if(_form1.B1Clicked){
            fromMountainsToPond(player);
        }
        else if(_form1.B2Clicked) {
            Town3(player);
        }
    }
    public void Town2(Character player){
        _form1.ResetButtons();
        _form1.ClearText();
          
        _form1.AddLine("This side of map is unavailable returning to last location...");
        StartPoint(player);
    }
    public void fromTown2ToDesert(Character player){
        _form1.ResetButtons();
        _form1.ClearText();
          
        _form1.AddLine("This side of map is unavailable returning to last location...");
        StartPoint(player);
    }
    public void fromTown2ToPond(Character player){
        _form1.ResetButtons();
        _form1.ClearText();
          
        _form1.AddLine("This side of map is unavailable returning to last location...");
        StartPoint(player);
    }
    public void pond(Character player)
    {
        _form1.ResetButtons();
        _form1.ClearText();

        _form1.AddLine(">As you climb out of the bog you are suddenly hit with the smell of fresh air and chirping of crickets.\r\n" +
                       "In front of you is a large pond and to the right of you is a muddy morass. To the left is a vast open space leading further down.\r\n" +
                       "Choose where would you like to go: ");
        _form1.EnableButtons();
        _form1.ChangeB1Text("Pond");
        _form1.ChangeB2Text("Morass");
        _form1.ChangeB3Text("Left");
        Form1.Wait.WaitOne();
        if (_form1.B2Clicked)
        {
            _form1.AddLine(">As you get closer to the reeds, the chirping intensifies to the point where your ears start to hurt.\r\n" +
                           ">You realise that these bug might be under the effect of the toxin.\r\n" +
                           ">Choose to continue through the reeds or turn back: ");
            _form1.ResetButtons();
            _form1.EnableButtons();
            _form1.ChangeB1Text("Continue");
            _form1.ChangeB2Text("Turn back");
            _form1.DisableB3();
            Form1.Wait.WaitOne();
            if (_form1.B1Clicked)
            {
                _form1.AddLine(">Continuing further through the reeds, the chirping almost becomes deafening but you are not able to see any crickets.\r\n" +
                               ">Since you can't see anything you decide to go back.\r\n" +
                               ">Choose to go back.");
                _form1.ResetButtons();
                _form1.EnableButtons();
                _form1.ChangeB1Text("Turn Back");
                _form1.ChangeB2Text("Turn Back");
                _form1.ChangeB3Text("Turn Back");
                Form1.Wait.WaitOne();
                if (_form1.B1Clicked || _form1.B2Clicked || _form1.B3Clicked)
                {
                    Creature creature = new Crazy("Big Cricket",true,30,5,4,4,2);
                    _form1.AddLine(">As you turn around to walk back, you see a humongous cricket which seems to be fairly interested in you.\r\n" +
                                   ">Then cricket makes a screeching sound and waves its leg towards you.Choose to fight or escape:");
                    _form1.ResetButtons();
                    _form1.EnableButtons();
                    _form1.ChangeB1Text("Attack");
                    _form1.ChangeB2Text("Escape");
                    _form1.DisableB3();
                    Form1.Wait.WaitOne();
                    if (_form1.B1Clicked)
                    {
                        player.Fight(player,creature);
                    }
                    else if (_form1.B2Clicked)
                    {
                        player.Escape(player,creature);
                    }
                    _form1.AddLine(">With final blow the cricket turns on its back and shrivels.\r\n" +
                                   ">You still cannot believe an insect can get so big. You go back to where you start.");
                    _form1.AddLine("Continue?");
                    _form1.ResetButtons();
                    _form1.EnableButtons();
                    _form1.ChangeB1Text("Continue");
                    _form1.ChangeB2Text("Continue");
                    _form1.DisableB3();
                    Form1.Wait.WaitOne();
                    pond(player);
                }
            }
            else if (_form1.B2Clicked)
            {
                _form1.AddLine(">You decide to turn back where you started.");
                pond(player);
            }
        }
        else if (_form1.B1Clicked)
        {
            _form1.AddLine(">You come closer to the pond and on the distance see something floating on the pond.\r\n" +
                           ">Upon closer inspection, you realise that these are some strange kind of duck with a turtle shell on their back.\r\n" +
                           ">These are turtle ducks! They look peaceful and also cute. Maybe this Toxin is not all bad after all?" +
                           ">Choose to attack or admire their cuteness. ");
            _form1.ResetButtons();
            _form1.EnableButtons();
            _form1.ChangeB1Text("Attack?");
            _form1.ChangeB2Text("Just Observe");
            _form1.DisableB3();
            Form1.Wait.WaitOne();
            if (_form1.B1Clicked)
            {
                _form1.AddLine(">Really?.. Fine. You try to attack the turtle duck");
                Creature creature = new Crazy("Baby turtle duck",false,1,1,1,1,1);
                player.Fight(player,creature);
                _form1.AddLine(">As you murder this innocent little turtle duck in cold blood you see something larger\r\n" +
                               ">in the distance coming towards you  with ferocious haste. It is the mother of the babies! She looks enraged\r\n" +
                               ">Choose to attack or escape: ");
                Creature newCreature = new Crazy("Mother turtle duck",true,40,5,10,10,3); 
                _form1.ResetButtons();
                _form1.EnableButtons();
                _form1.ChangeB1Text("Attack");
                _form1.ChangeB2Text("Escape");
                _form1.DisableB3();
                Form1.Wait.WaitOne();
                if (_form1.B1Clicked)
                {
                    player.Fight(player,newCreature);
                }
                else if(_form1.B2Clicked)
                {
                    player.Escape(player,newCreature);
                }
                _form1.AddLine(">With the enormous guilt of what you have done you decide to leave this pond for good.\r\n" +
                               ">Choose to go to vast open area you saw before, the stone road you now saw going into a human resident\r\n" +
                               ">in the distance or go back to the swamp");
                _form1.ResetButtons();
                _form1.EnableButtons();
                _form1.ChangeB1Text("Open Area");
                _form1.ChangeB2Text("Stone Road");
                _form1.ChangeB3Text("Swamp");
                Form1.Wait.WaitOne();
                if (_form1.B1Clicked)
                {
                    fromPondToDesert(player);
                }
                else if (_form1.B2Clicked)
                {
                    //fromPondToMarket(player)
                }
                else if(_form1.B3Clicked)
                {
                    fromPondToMountains(player);
                }
            }
            else if (_form1.B2Clicked)
            {
                _form1.AddLine(">You are mesmerized by the cuteness of these animals and you decide to pet one of them.\r\n" +
                               ">The moment you reach out for one of them, it bites your finger and they all swim away.\r\n" +
                               ">You feel a little bit of pain but when you look at your finger, you see that the animal has left behind some\r\n" +
                               ">saliva residue which can pass as a sample.");
                player.setHealth(player.getHealth()-1);
                if (player.getHealth() <= 0)
                {
                    player.setHealth(0);
                    player.playerDead();
                }
                _form1.SetHealthBar((int)player.getHealth());
                player.setSampleCollected(player.getSampleCollected() + 1);
                _form1.ChangeCurrentScores();
                _form1.AddLine(">You lost 1 hp and collected 1 sample as a result of this friendly encounter.");
                _form1.AddLine(player.printInfo());
                
                _form1.AddLine(">Choose to go to vast open area you saw before, the stone road you now saw going into a human resident\r\n" +
                               ">in the distance or go back to the swamp");
                _form1.ResetButtons();
                _form1.EnableButtons();
                _form1.ChangeB1Text("Open Area");
                _form1.ChangeB2Text("Stone Road");
                _form1.ChangeB3Text("Swamp");
                Form1.Wait.WaitOne();
                if (_form1.B1Clicked)
                {
                    fromPondToDesert(player);
                }
                else if (_form1.B2Clicked)
                {
                    //fromPondToMarket(player)
                }
                else if(_form1.B3Clicked)
                {
                    fromPondToMountains(player);
                }
            }
        }
        else if(_form1.B3Clicked)
        {
            fromPondToDesert(player);
        }
    }
    public void fromMountainsToPond(Character player)
    {
       _form1.ResetButtons();
       _form1.ClearText();
        
       Creature newCreature=new Bird("Wyvern",false,55,4,6,4,3);//runtime polymorphism
       
       _form1.AddLine(">Now you are passing throgh a swamp.Insects flying around annoy you.But compared to the mountain it is nothing.\r\n"+
                ">When you stop to have a rest you notice aloe vera plant nearby a tree.(it adds 25 health automatically)\r\n"+
                ">Press to take it or to leave it.");
        
        _form1.EnableButtons();
        _form1.ChangeB1Text("Take");
        _form1.ChangeB2Text("Leave");
        _form1.DisableB3();
        Form1.Wait.WaitOne();
        
        if(_form1.B1Clicked) {
            player.setHealth(player.getHealth()+25);
            if (player.getHealth() >= 100)
            {
                player.setHealth(100);
            }
            _form1.SetHealthBar((int)player.getHealth());
            _form1.AddLine(">Your new health: "+player.getHealth());
        }
        else if (_form1.B2Clicked)
        {
            _form1.AddLine(">You left the plant and kept going");
        }
        _form1.ResetButtons();
        _form1.AddLine(">You keep walking and you see a scream above you.You look up and see a huge birdish creature flying.It seems intimidating.\r\n"+
                       ">You suppose that is a "+newCreature.GetCreatureName()+"It seems it has nothing to do with you.\r\n" +
                       "Press to attack it 2 to keep going");
        _form1.EnableButtons();
        _form1.ChangeB1Text("Attack");
        _form1.ChangeB2Text("Keep Going");
        _form1.DisableB3();
        Form1.Wait.WaitOne();
        
        if(_form1.B1Clicked){
            player.Fight(player, newCreature);
        }
        else if(_form1.B2Clicked)
        {
            _form1.AddLine(">You left the creature alone and kept going.");
        }
        _form1.ResetButtons();
        _form1.AddLine(">You keep moving and see the pond clearly in the distance.\r\n" +
                       "Press to go to the pond or press to return back to the mountain.");
       
        _form1.EnableButtons();
        _form1.ChangeB1Text("Pond");
        _form1.ChangeB2Text("Mountains");
        _form1.DisableB3();
        Form1.Wait.WaitOne();
        if(_form1.B1Clicked) {
            pond(player);
        }
        else if(_form1.B2Clicked){
            mountain(player);
        }
    }
    public void fromPondToMountains(Character player){
        _form1.ResetButtons();
        _form1.ClearText();
          
        _form1.AddLine("This side of map is unavailable returning to last location...");
        pond(player);
    
    }
    public void fromPondToDesert(Character player){
        _form1.ResetButtons();
        _form1.ClearText();
          
        _form1.AddLine("This side of map is unavailable returning to last location...");
        pond(player);
    }
    public void fromDesertToPond(Character player){
        _form1.ResetButtons();
        _form1.ClearText();
          
        _form1.AddLine("This side of map is unavailable returning to last location...");
        desert(player);
    }
        
    }
}