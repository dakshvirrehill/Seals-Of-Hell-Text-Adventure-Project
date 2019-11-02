#pragma once
#ifndef REGION_H
#define REGION_H
#include "BasicObject.h"
#include "json.hpp"
class Room;
/*
################
THIS IS THE REGION CLASS IT JUST HOLDS THE POINTER TO IT'S ENTRY ROOM AND HAS A NAME AND STORY OF ITS OWN
################
*/
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