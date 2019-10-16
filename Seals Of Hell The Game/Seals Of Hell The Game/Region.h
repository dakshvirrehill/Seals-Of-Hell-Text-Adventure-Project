#pragma once
#ifndef REGION_H
#define REGION_H
#include <string>
class Room;
class Region
{
	std::string mName;
	std::string mStory;
	Room* mEntryRoom;
	Room* mExitRoom;
public:
	Region();
	~Region();
	std::string& getName() { return mName; }
	std::string& getStory() { return mStory; }
};
#endif