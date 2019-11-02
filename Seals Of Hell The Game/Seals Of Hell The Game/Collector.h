#pragma once
#ifndef COLLECTOR_H
#define COLLECTOR_H
#include "IUpdatable.h"
#include "IInteractable.h"
/*
################
A COLLECTOR IS AN UPDATING OBJECT THAT COLLECTS GIVEABLE PICKABLE OBJECTS
IF IT HAS NOT COLLECTED GIVEABLE OBJECT, IT KEEPS ALL OBJECTS IT CAN UPDATE
AS NOT INTERACTABLE AND NOT VISIBLE
ONCE IT HAS COLLECTED THOSE OBJECTS IT MAKES ALL THE OBJECTS IT CAN UPDATE
AS INTERACTABLE AND VISIBLE AND ITSELF AS THE OPPOSITE
################
*/
class Collector : public IUpdatable,public IInteractable
{
public:
	Collector() : IUpdatable(), IInteractable() {}
	~Collector();
	void onEnable() override;
	void update() override;
	void endUpdate() override;
	void giveObject(IInteractable*) override;
	json::JSON getItemJSON() override;
	std::string getType() override { return "Collector"; }
};
#endif