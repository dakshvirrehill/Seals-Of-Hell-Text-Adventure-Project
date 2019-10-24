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
	void update() override;
	void enemyDeath() override;
};
#endif