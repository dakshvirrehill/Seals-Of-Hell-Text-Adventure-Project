#pragma once
#ifndef BASIC_OBJECT_H
#define BASIC_OBJECT_H
#include <string>
class BasicObject
{
	int mUniqueID;
	std::string mName;
	std::string mStory;
protected:
	BasicObject();
	virtual ~BasicObject();
public:
	void Initialize(std::string&, std::string&, int&);
	int& getUniqueID() { return mUniqueID; }
	std::string& getName() { return mName; }
	std::string& getStory() { return mStory; }
};
#endif