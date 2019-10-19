#pragma once
#ifndef INPUT_MANAGER_H
#define INPUT_MANAGER_H
#include<functional>
#include<map>
#include<string>
class IInteractable;
class InputManager
{
private:
	inline explicit InputManager() :mInteractableCommands(),mSingleCommands() {}
	inline ~InputManager() {}
	inline explicit InputManager(InputManager const&) {}
	inline InputManager& operator=(InputManager const&)
	{
		return *this;
	}
	std::map<std::string, std::function<bool(IInteractable*)>> mInteractableCommands;
	std::map<std::string, std::function<bool()>> mSingleCommands;
protected:
	inline static InputManager& instance()
	{
		static InputManager mInstance;
		return mInstance;
	}
	void initialize();
	bool help();
	friend class GameManager;
};
#endif