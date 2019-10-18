#include "Room.h"

Room::Room()
	:BasicObject()
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
}

const void Room::AddExitRoom(Room* pRoom)
{
	if (pRoom == nullptr)
	{
		return;
	}
}
