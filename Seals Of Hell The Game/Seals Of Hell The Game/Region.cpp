#include "Region.h"
#include <iostream>
Region::Region()
	:BasicObject(),mEntryRoom(nullptr)
{
}

Region::~Region()
{
	
}

void Region::initialize(Room* pEntryRoom)
{
	mEntryRoom = pEntryRoom;
}

void Region::look()
{
	std::cout << getName() << std::endl <<std::endl;
	std::cout << getStory() << std::endl << std::endl <<std::endl;
}

Room* Region::getStartingRoom()
{
	return mEntryRoom;
}
