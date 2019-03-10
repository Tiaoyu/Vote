# Vote
An app of Voting

Round

| round_id         | varchar(64)  |
| ---------------- | ------------ |
| round_desc       | varchar(255) |
| round_begin_time | timestamp    |
| round_end_time   | timestamp    |

Target

| target_id      | varchar(64)  |
| -------------- | ------------ |
| target_desc    | varchar(255) |
| targetype_id   | int(11)      |
| target_content | varchar(255) |
| round_id       | varchar(64)  |

Choice

| choice_id      | varchar(64)  |
| -------------- | ------------ |
| choice_content | varchar(255) |
| choise_value   | int(11)      |
| round_id      | varchar(64)  |

Targetype

| targetype_id   | int(11)      |
| -------------- | ------------ |
| targetype_desc | varchar(255) |

TargetChoice

| target_id | varchar(64) |
| --------- | ----------- |
| choice_id | varchar(64) |

User

| user_id   | varchar(64) |
| --------- | ----------- |
| user_name | varchar(64) |
| user_mail | varchar(32) |
| user_pwd  | varchar(64) |
|           |             |


Vote

| vote_id   | varchar(64) |
| --------- | ----------- |
| vote_time | timestamp   |
| target_id | varchar(64) |
| choice_id | varchar(64) |
| user_id   | varchar(64) |

```mermaid
graph LR
Choice --n--> TargetChoice
TargetChoice --n--> Target
```
