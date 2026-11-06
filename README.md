Overview and controls: This is a snake game eating apples, and WASD to move

OOP: Food is abstract, with Apple and GoldenApple inheriting it. OnEaten() is overridden, which is polymorphism. FruitFactory also has two subclasses. 

Singleton:

What it is: one globally accessible instance of a class

Justification: GameManager holds the score and game-over state that the snake, fruit and UI all need. FruitSpawnManager needs exactly one spawner and one current fruit. Both avoid passing references around or creating duplicates

Factory:

What it is: the creation of objects is delegated to a factory instead of using new or Instantiate directly

Justification: the snake and spawner don’t need to know which fruit type they're getting. To add a new fruit (such as a poison apple), I add one class and one factory without touching the spawn logic. Each fruit's setup (colour, bonus) lives in its own factory
