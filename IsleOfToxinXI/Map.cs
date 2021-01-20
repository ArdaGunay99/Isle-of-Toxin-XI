using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace IsleOfToxinXI
{
    public class Map
    {
        private Form1 _form1 = (Form1) Application.OpenForms["Form1"];
        
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
                // fromStartToForest(player);
            }
            else if(_form1.B2Clicked )
            {
                // fromStartToDesert(player);
            }
            else if(_form1.B3Clicked)
                fromStartToTown1(player);
        }

    public void fromStartToTown1(Character player)
    {
        _form1.ClearText();

        _form1.ResetButtons();
        _form1.AddLine(">Now you are on a road with huge rocks on both sides that directs you to\n>somewhere.It's obviously made by some kind of civilization"
                           +"\r\n>While you are walking you saw a aloe vera plant\n >which can be used as medicine(it adds 25 health automatically)\r\n" +
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
                ">You look at the database and learn that it's a"+newCreature.GetCreatureName()+"and it is hostile and coming to attack you!\r\n" +
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
        _form1.AddLine(">Now you are at the end of the road. There seems to be a abandoned human resident press to go in or to turn back:  ");
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
       
        _form1.AddLine(">You go out in the open again and just as you were leaving you here a battle cry coming from behind you.\n" +
                ">You turn around and see a human which has been effected by the toxin.\n" +
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
        _form1.AddLine("There seems to be a path leading into another human resident.\n" +
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
                "\n>He is on the ground and bleeding! He sees you and Calls you with your name: Semiramis." +
                "\n>You go near him and see that he has lost a leg and stabbed through the stomach.\n" +
                ">he says that there is nothing to do and that he is going to die soon.\n" +
                ">Before he dies he says that you can take his rod and use it to combine it with his knife.\n" +
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
        
        _form1.AddLine(">You go into the resident and look around for Jack's murderer. Then you hear a screech form above.\n" +
                ">You look up and see that a giant "+ newCreature.GetCreatureName()+" is coming for you. This giant wasp is probably Jack's killer.\n" +
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
        _form1.AddLine(">you now have two roads in front of you\n" +
                " press to go to the mountains or to go to another human resident or 3 to return: ");
       
        _form1.EnableButtons();
        _form1.ChangeB1Text("Mountains");
        _form1.ChangeB2Text("Resident");
        _form1.ChangeB3Text("Return");
        Form1.Wait.WaitOne();
        
        if (_form1.B1Clicked)
        {
            // mountain(player);
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
    // public void fromStartToForest(Character player){
    //     int choice;
    //     System.out.println("Press 1 to continue or 2 to exit program");
    //     choice = input.nextInt();
    //     if(choice==2){
    //         System.out.println("Closing...");
    //         System.exit(0);
    //     }
    //     System.out.println("This side of map is unavailable returning to last location...");
    //     StartPoint(player);
    // }
    // public void fromStartToDesert(Character player){
    //     int choice;
    //     System.out.println("Press 1 to continue or 2 to exit program");
    //     choice = input.nextInt();
    //     if(choice==2){
    //         System.out.println("Closing...");
    //         System.exit(0);
    //     }
    //     System.out.println("This side of map is unavailable returning to last location...");
    //     StartPoint(player);
    //
    // }
    // public void forest(Character player){
    //     int choice;
    //     System.out.println("Press 1 to continue or 2 to exit program");
    //     choice = input.nextInt();
    //     if(choice==2){
    //         System.out.println("Closing...");
    //         System.exit(0);
    //     }
    // }
    // public void desert(Character player){
    //     int choice;
    //     System.out.println("Press 1 to continue or 2 to exit program");
    //     choice = input.nextInt();
    //     if(choice==2){
    //         System.out.println("Closing...");
    //         System.exit(0);
    //     }
    // }
    // public void seaSide(Character player){
    //     int choice;
    //     System.out.println("Press 1 to continue or 2 to exit program");
    //     choice = input.nextInt();
    //     if(choice==2){
    //         System.out.println("Closing...");
    //         System.exit(0);
    //     }
    // }
    // public void mountain(Character player){
    //     int choice;
    //     System.out.println("Press 1 to continue or 2 to exit program");
    //     choice = input.nextInt();
    //     if(choice==2){
    //         System.out.println("Closing...");
    //         System.exit(0);
    //     }
    //     Item newItem=new Item ("rotten Axe",11 ,80 );
    //     Creature newCreature = new Crazy("The Dead",true,25,3,3,4,2);//runtime polymorphism
    //     System.out.println("Nobody knows why but you are now on the top of the mountain.Thanks to the snowy storm your line of sight is pretty limited.\n"+
    //             "The only thing that you can feel is an immense cold.You wander around pointlessly.By the time you are about to loose your hopes you slightly see a small cottage right in the woods.\n "
    //             +"You get in the cottage and among all the old stuff in the cottage 2 things get your attention. A body seems to be dead and a rotten axe.");
    //     newItem.printInfo();
    //     System.out.println("Press 1 to take the rotten axe or 2 to leave it:");
    //     if(choice==1) {
    //         player.setHealth(player.getHealth()-4);
    //         player.addToCharInventory(newItem);
    //         System.out.println("You kneel down to get the rotten axe.As soon as you start standing back up you see something running towards you.It catches you unbalanced.\n"+
    //                 "It hits you once and you loose 4 health points.Now your health is: "+player.getHealth()+"The dead body is after you\n");
    //     }
    //     else {
    //         System.out.println("You see the dead body slowly getting up.It seems to not like you.");
    //     }
    //     System.out.println("It is"+ newCreature.getCreatureName() +"Press 1 to fight or press 2 to escape.");
    //     choice=input.nextInt();
    //     if(choice==1) {
    //         player.fight(player, newCreature);
    //     }
    //     else {
    //         player.escape(player, newCreature);
    //     }
    //     System.out.println("You immediately leave the cottage.You find a high spot where you can see things more clearly\n"+
    //             "You see a swamp in the distance leading to a pond.Press 1 to go to the pond or press 2 to get back to the town.");
    //     choice=input.nextInt();
    //     if(choice==1) {
    //         fromMountainsToPond(player);
    //     }
    //     else if(choice==2) {
    //         Town3(player);
    //     }
    // }
    // public void Town2(Character player){
    //     int choice;
    //     System.out.println("Press 1 to continue or 2 to exit program");
    //     choice = input.nextInt();
    //     if(choice==2){
    //         System.out.println("Closing...");
    //         System.exit(0);
    //     }
    // }
    // public void fromTown2ToDesert(Character player){
    //     int choice;
    //     System.out.println("Press 1 to continue or 2 to exit program");
    //     choice = input.nextInt();
    //     if(choice==2){
    //         System.out.println("Closing...");
    //         System.exit(0);
    //     }
    //     System.out.println("This side of map is unavailable returning to last location...");
    //     Town2(player);
    // }
    // public void fromTown2ToPond(Character player){
    //     int choice;
    //     System.out.println("Press 1 to continue or 2 to exit program");
    //     choice = input.nextInt();
    //     if(choice==2){
    //         System.out.println("Closing...");
    //         System.exit(0);
    //     }
    //     System.out.println("This side of map is unavailable returning to last location...");
    //     Town2(player);
    // }
    // public void pond(Character player){
    //     int choice;
    //     System.out.println("Press 1 to continue or 2 to exit program");
    //     choice = input.nextInt();
    //     if(choice==2){
    //         System.out.println("Closing...");
    //         System.exit(0);
    //     }
    //
    // }
    // public void fromMountainsToPond(Character player){
    //     int choice;
    //     System.out.println("Press 1 to continue or 2 to exit program");
    //     choice = input.nextInt();
    //     if(choice==2){
    //         System.out.println("Closing...");
    //         System.exit(0);
    //     }
    //     Creature newCreature=new Bird("Wyvern",false,55,4,6,4,3);//runtime polymorphism
    //     System.out.println("Now you are passing throgh a swamp.Insects flying around annoy you.But compared to the mountain it is nothing.\n"+
    //             "When you stop to have a rest you notice aloe vera plant nearby a tree.(it adds 25 health automatically)\n"+
    //             "Press 1 to take it or press 2 to leave it.");
    //     choice=input.nextInt();
    //     if(choice==1) {
    //         player.setHealth(player.getHealth()+25);
    //         System.out.println("Your new health: "+player.getHealth());
    //     }
    //     System.out.println("You keep walking and you see a scream above you.You look up and see a huge birdish creature flying.It seems intimidating./n"+
    //             "You suppose that is a "+newCreature.getCreatureName()+"It seems it has nothing to do with you.Press 1 to attack it or press 2 to keep going");
    //     choice=input.nextInt();
    //     if(choice==1) {
    //         player.fight(player, newCreature);
    //     }
    //     System.out.println("You keep moving and see the pond clearly in the distance.Press 1 to go to the pond or press 2 to return back to the mountain.");
    //     choice=input.nextInt();
    //     if(choice==1) {
    //         pond(player);
    //     }
    //     else {
    //         mountain(player);
    //     }
    // }
    // public void fromPondToMountains(Character player){
    //     int choice;
    //     System.out.println("Press 1 to continue or 2 to exit program");
    //     choice = input.nextInt();
    //     if(choice==2){
    //         System.out.println("Closing...");
    //         System.exit(0);
    //     }
    //     System.out.println("This side of map is unavailable returning to last location...");
    //     pond(player);
    //
    // }
    // public void fromPondToDesert(Character player){
    //     int choice;
    //     System.out.println("Press 1 to continue or 2 to exit program");
    //     choice = input.nextInt();
    //     if(choice==2){
    //         System.out.println("Closing...");
    //         System.exit(0);
    //     }
    //     System.out.println("This side of map is unavailable returning to last location...");
    //     pond(player);
    // }
    // public void fromDesertToPond(Character player){
    //     int choice;
    //     System.out.println("Press 1 to continue or 2 to exit program");
    //     choice = input.nextInt();
    //     if(choice==2){
    //         System.out.println("Closing...");
    //         System.exit(0);
    //     }
    //     System.out.println("This side of map is unavailable returning to last location...");
    //     desert(player);
    // }
        
    }
}