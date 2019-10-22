#pragma once
#ifndef COLLECTOR_H
#define COLLECTOR_H
#include "IUpdatable.h"
#include "IInteractable.h"
class Collector : public IUpdatable,public IInteractable
{
public:
	void update() override;
};
#endif