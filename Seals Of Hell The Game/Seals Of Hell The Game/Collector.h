#pragma once
#ifndef COLLECTOR_H
#define COLLECTOR_H
#include "IUpdatable.h"
#include "IInteractable.h"
class Collector : public IUpdatable,public IInteractable
{
public:
	Collector() : IUpdatable(), IInteractable() {}
	~Collector();
	void onEnable() override;
	void update() override;
	void endUpdate() override;
	void giveObject(IInteractable*) override;
};
#endif