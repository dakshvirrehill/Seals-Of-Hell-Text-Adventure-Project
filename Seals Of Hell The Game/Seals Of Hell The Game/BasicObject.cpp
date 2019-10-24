#include "BasicObject.h"

BasicObject::BasicObject()
	:mName(""),mStory("")
{
}

BasicObject::~BasicObject()
{
}

void BasicObject::initialize(std::string pName, std::string pStory)
{
	mName = pName;
	mStory = pStory;
}
