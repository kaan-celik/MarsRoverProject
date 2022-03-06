#MarsRoverProject

#Scenario:

1. All inputs read from "Inputs\inputs.txt" file.
2. Then Planet create according to given planet inputs of first line.
3. The remaining inputs adapt to the "Commands" class for rover coordinate and movement
4. If the rover coordinates are valid then it's created by the "RoverFactory" class and sended to planet.
5. Then, program checks the rover movement commands are valid. If its true then rover starts to move.In each movement step, it controls the reaching upper or lover bound of planet.
When the rover reachs the any of planet bound, then it cannot go the forward until it's face changed.
6. If the rover completes its own movement, Then print the status of the rover and start's creation of next rover. It continues until there is no command in the command list.



#Mark Ups:

0. Inputs are readed from file. Path : "Inputs\inputs.txt"
1. "Rover" class implemented by "IRover" interface in "Business\Entities\Interface"
2. A rover created by "RoverFactory" class
3. Inputs are adapted to "Commands" class
4. Coordinates adapted to "Coordinate" class
5. Input validation provides with "CommandManager"
6. MSTest extension is used for the unit test, 