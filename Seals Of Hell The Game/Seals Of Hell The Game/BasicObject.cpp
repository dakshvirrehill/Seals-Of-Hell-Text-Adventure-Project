#include "BasicObject.h"

BasicObject::BasicObject()
	:mName(""),mStory("")
{
}

BasicObject::~BasicObject()
{
}

void BasicObject::Initialize(std::string& pName, std::string& pStory)
{
	mName = pName;
	mStory = pStory;
}
