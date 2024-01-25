CREATE TABLE "Survey"(
    "id" SERIAL,
    "title" TEXT NOT NULL,
    "description" TEXT NOT NULL
);
ALTER TABLE
    "Survey" ADD PRIMARY KEY("id");
CREATE TABLE "Answer"(
    "id" SERIAL,
    "text" TEXT NOT NULL,
    "question_id" INTEGER NOT NULL
);
ALTER TABLE
    "Answer" ADD PRIMARY KEY("id");
CREATE TABLE "Result"(
    "id" SERIAL,
    "interview_id" INTEGER NOT NULL,
    "user_answer_id" INTEGER NOT NULL
);
ALTER TABLE
    "Result" ADD PRIMARY KEY("id");
CREATE TABLE "Interview"(
    "id" SERIAL,
    "user_id" TEXT NOT NULL,
    "session_id" TEXT NOT NULL
);
ALTER TABLE
    "Interview" ADD PRIMARY KEY("id");
CREATE TABLE "Question"(
    "id" SERIAL,
    "text" TEXT NOT NULL,
    "survey_id" INTEGER NOT NULL,
    "sequence_number" INTEGER NOT NULL
);
ALTER TABLE
    "Question" ADD PRIMARY KEY("id");
ALTER TABLE
    "Result" ADD CONSTRAINT "result_user_answer_id_foreign" FOREIGN KEY("user_answer_id") REFERENCES "Answer"("id");
ALTER TABLE
    "Answer" ADD CONSTRAINT "answer_question_id_foreign" FOREIGN KEY("question_id") REFERENCES "Question"("id");
ALTER TABLE
    "Result" ADD CONSTRAINT "result_interview_id_foreign" FOREIGN KEY("interview_id") REFERENCES "Interview"("id");
ALTER TABLE
    "Question" ADD CONSTRAINT "question_survey_id_foreign" FOREIGN KEY("survey_id") REFERENCES "Survey"("id");