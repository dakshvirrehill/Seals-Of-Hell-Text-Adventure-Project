#include "Room.h"

Room::Room()
	:BasicObject(),mExitRooms()
{
}

Room::~Room()
{
	
}

void Room::RemoveExitRoom(Room* pRoom)
{
	if (pRoom == nullptr)
	{
		return;
	}
	if (mExitRooms.find(pRoom->getUniqueID()) == mExitRooms.end())
	{
		return;
	}
	mExitRooms.erase(pRoom->getUniqueID());
}

const void Room::AddExitRoom(Room* pRoom)
{
	if (pRoom == nullptr)
	{
		return;
	}
	mExitRooms.emplace(pRoom->getUniqueID(), pRoom);
}
