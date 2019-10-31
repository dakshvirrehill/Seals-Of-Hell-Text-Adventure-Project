#pragma once
#ifndef REGION_H
#define REGION_H
#include "BasicObject.h"
#include "json.hpp"
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
	json::JSON getItemJSON();
};
#endif