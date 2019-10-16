#pragma once
#ifndef REGION_H
#define REGION_H
#include <string>
class Region
{
	std::string mName;
	std::string mStory;
public:
	Region();
	Region(std::string& pName, std::string& pStory);
	~Region();
	std::string& getName() { return mName; }
	std::string& getStory() { return mStory; }
};
#endif