# Vote
An app of Voting

Round

| round_id         | bigint(20)   |
| ---------------- | ------------ |
| round_desc       | varchar(255) |
| round_begin_time | timestamp    |
| round_end_time   | timestamp    |

Target

| target_id      | bigint(20)   |
| -------------- | ------------ |
| target_desc    | varchar(255) |
| target_type    | int(11)      |
| target_content | varchar(255) |
| round_id       | bigint(20)   |

Choice

| choice_id      | bigint(20)   |
| -------------- | ------------ |
| choice_content | varchar(255) |
| choise_value   | int(11)      |
| target_id      | bigint(20)   |

Targetype

| targetype_id   | int(11)      |
| -------------- | ------------ |
| targetype_desc | varchar(255) |

User

| user_id   | bigint(20)  |
| --------- | ----------- |
| user_name | varchar(64) |
| user_mail | varchar(32) |
| user_pwd  | varchar(64) |
|           |             |


Vote

| vote_id   | bigint(20) |
| --------- | ---------- |
| vote_time | timestamp  |
| choice_id | bigint(20) |
| user_id   | bigint(20) |
