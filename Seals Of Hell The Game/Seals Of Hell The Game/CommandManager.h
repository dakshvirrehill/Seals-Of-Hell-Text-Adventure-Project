#pragma once
#ifndef COMMAND_MANAGER_H
#define COMMAND_MANAGER_H
#include<functional>
#include<map>
#include<string>
class IInteractable;
class CommandManager
{
private:
	inline explicit CommandManager() :mInteractableCommands(),mSingleCommands(),mInitialzed(false) {}
	inline ~CommandManager() {}
	inline explicit CommandManager(CommandManager const&) :mInteractableCommands(), mSingleCommands(), mInitialzed(false) {}
	inline CommandManager& operator=(CommandManager const&)
	{
		return *this;
	}
	std::map<std::string, std::function<bool(IInteractable*)>> mInteractableCommands;
	std::map<std::string, std::function<void()>> mSingleCommands;
	bool mInitialzed;
protected:
	inline static CommandManager& instance()
	{
		static CommandManager mInstance;
		return mInstance;
	}
	void initialize();
	void help();
	std::function<bool(IInteractable*)> getInteractableCommandPointer(std::string& pCommandVerb);
	std::function<void()> getSingleCommandPointer(std::string& pCommandVerb);
	friend class GameManager;
};
#endif