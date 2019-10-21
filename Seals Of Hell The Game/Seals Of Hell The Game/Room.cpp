#include "Room.h"
#include <iostream>
Room::Room()
	:BasicObject()
{
}

Room::~Room()
{
	
}

void Room::initialize()
{
}

void Room::look()
{
	std::cout << getName() << std::endl;
	std::cout << getStory() << std::endl << std::endl << std::endl;
	//call lookobject on all interactables
}
