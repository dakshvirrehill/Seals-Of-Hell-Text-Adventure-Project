#include "Region.h"
#include <iostream>
#include "Room.h"
Region::Region()
	:BasicObject(),mEntryRoom(nullptr)
{
}

Region::~Region()
{
	mEntryRoom = nullptr;
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

json::JSON Region::getItemJSON()
{
	json::JSON aJSON = json::JSON::Object();
	aJSON["mName"] = getName();
	aJSON["mStory"] = getStory();
	aJSON["mEntryRoom"] = mEntryRoom->getName();
	return aJSON;
}
