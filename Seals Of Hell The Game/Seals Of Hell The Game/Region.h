#pragma once
#ifndef REGION_H
#define REGION_H
#include "BasicObject.h"
class Room;
class Region : public BasicObject
{
	Room* mEntryRoom;
public:
	Region();
	~Region();
	void initialize(Room*);
	void look();
	Room* getStartingRoom();
};
#endif