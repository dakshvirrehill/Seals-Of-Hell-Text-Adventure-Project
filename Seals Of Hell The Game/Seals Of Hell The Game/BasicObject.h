#pragma once
#ifndef BASIC_OBJECT_H
#define BASIC_OBJECT_H
#include <string>
class BasicObject
{
	std::string mName;
	std::string mStory;
protected:
	BasicObject();
	virtual ~BasicObject();
public:
	void initialize(std::string&, std::string&);
	std::string& getName() { return mName; }
	std::string& getStory() { return mStory; }
};
#endif