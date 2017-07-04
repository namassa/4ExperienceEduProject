public interface IMonster
{
    //Every creature must have some hp points
    int healthPoints { get; set; }
    //Each monster must have some value to know how fast change their position
    float movementSpeed { get; set; }
    //How many damage moster can deal
    int damage { get; set; }
    //function tell us where monster is moving at present
    void WhereAmIGoing();
    //method which moving the object to random position
    void MoveTo();
    //method calls only if enter enemy collider and dealing damage
    void DoDamage();
    //method calls only if enter friend collider and saying hello
    void SayHello();
}