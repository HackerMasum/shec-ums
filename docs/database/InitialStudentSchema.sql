CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20261029072516_InitialStudentSchema') THEN
    CREATE TABLE students (
        id uuid NOT NULL,
        student_number character varying(50) NOT NULL,
        first_name character varying(100) NOT NULL,
        last_name character varying(100) NOT NULL,
        CONSTRAINT "PK_students" PRIMARY KEY (id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20261029072516_InitialStudentSchema') THEN
    CREATE UNIQUE INDEX "IX_students_student_number" ON students (student_number);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20261029072516_InitialStudentSchema') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20261029072516_InitialStudentSchema', '10.0.11');
    END IF;
END $EF$;
COMMIT;
