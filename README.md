# Task Execution System Readme

This document outlines the steps and procedures for executing tasks within the system. The system handles task assignment, asynchronous execution, task completion, executing pending tasks, and handling worker shutdown scenarios.

## Steps to Execute the Task

### 1. Add the Task

- When a user requests to execute a task, follow these steps:
  - Add the task to the list of tasks or the database in a real-world scenario.
  - Check for available nodes that can execute the task.
  - If available nodes exist, assign the task to one of them and mark the node as busy.
  - Set the status of the task as "Running".
  - If no available nodes are found, push the task into a queue named "TaskToExecute" and mark the task status as "Pending".

### 2. Execute the Task

- To execute a task, perform the following actions:
  - Configure the worker to execute the task asynchronously.
  - When the task is triggered, call a service to perform the necessary work, such as fetching a meme URL and saving an image if applicable.
  - Respond with an "OK" message to indicate the successful initiation of the task.

### 3. Task Completion Handling

- Handle task completion using the following steps:
  - Configure the worker to call the "TaskExecutor" service upon task completion or failure.
  - The "TaskExecutor" API updates the task status and the associated node based on the response received.
  - In case of task failure, also check the health of the node and adjust the status accordingly.

### 4. Execute Pending Tasks

- Execute pending tasks using the following approach:
  - Regularly check the "TaskToExecute" queue to identify pending tasks using a background job.
  - If both pending tasks and available nodes exist, execute the tasks using the previously described steps.
  - Also we will check for pending tasks when we change the node status to 'available' from Worker API callback.

### 5. Worker Shutdown Handling

- Handle worker shutdown scenarios as follows:
  - Set up a background job that runs every 5 minutes.
  - The job identifies tasks in the "Pending" state for more than 5 minutes.
  - Check the health of corresponding nodes and update both the task and node statuses based on the checks.
  - Additionally, call the execute Task method to check for pending tasks and available nodes to execute them.


