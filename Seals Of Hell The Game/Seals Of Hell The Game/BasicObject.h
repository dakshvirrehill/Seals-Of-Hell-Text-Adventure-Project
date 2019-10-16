#pragma once
#ifndef BASIC_OBJECT_H
#define BASIC_OBJECT_H
#include <string>
class BasicObject
{
protected:
	int mUniqueID;
	std::string mName;
	std::string mStory;
public:
	BasicObject();
	virtual ~BasicObject();
	void Initialize(std::string&, std::string&, int&);
	virtual int& getUniqueID() = 0;
	virtual std::string& getName() = 0;
	virtual std::string& getStory() = 0;
};
#endif