#pragma once
#ifndef REGION_H
#define REGION_H
#include <string>
#include "BasicObject.h"
class Room;
class Region : public BasicObject
{
	Room* mEntryRoom;
	Room* mExitRoom;
public:
	Region();
	~Region();
};
#endif