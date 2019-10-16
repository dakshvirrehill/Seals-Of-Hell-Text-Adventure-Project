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
	virtual std::string& getName() override { return mName; }
	virtual std::string& getStory() override { return mStory; }
	virtual int& getUniqueID() override { return mUniqueID; }
};
#endif