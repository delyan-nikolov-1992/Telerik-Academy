-- MySQL Script generated by MySQL Workbench
-- 08/23/14 20:26:32
-- Model: New Model    Version: 1.0
SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema University
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `University` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `University` ;

-- -----------------------------------------------------
-- Table `University`.`Faculties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Faculties` (
  `FacultyID` INT NOT NULL AUTO_INCREMENT,
  `FacultyName` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`FacultyID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Departments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Departments` (
  `DepartmentID` INT NOT NULL AUTO_INCREMENT,
  `DepartmentName` VARCHAR(50) NOT NULL,
  `FacultyID` INT NOT NULL,
  PRIMARY KEY (`DepartmentID`, `FacultyID`),
  INDEX `IX_Departments_FacultyID` (`FacultyID` ASC),
  CONSTRAINT `FK_Departments_Faculties`
    FOREIGN KEY (`FacultyID`)
    REFERENCES `University`.`Faculties` (`FacultyID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Professors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Professors` (
  `ProfessorID` INT NOT NULL AUTO_INCREMENT,
  `ProfessorFirstName` VARCHAR(50) NOT NULL,
  `ProfessorLastName` VARCHAR(50) NOT NULL,
  `DepartmentID` INT NOT NULL,
  PRIMARY KEY (`ProfessorID`, `DepartmentID`),
  INDEX `IX_Professors_DepartmentID` (`DepartmentID` ASC),
  CONSTRAINT `FK_Professors_Departments`
    FOREIGN KEY (`DepartmentID`)
    REFERENCES `University`.`Departments` (`DepartmentID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Courses` (
  `CourseID` INT NOT NULL AUTO_INCREMENT,
  `CourseName` VARCHAR(50) NOT NULL,
  `DepartmentID` INT NOT NULL,
  `ProfessorID` INT NOT NULL,
  PRIMARY KEY (`CourseID`, `DepartmentID`, `ProfessorID`),
  INDEX `IX_Courses_DepartmentID` (`DepartmentID` ASC),
  INDEX `IX_Courses_ProfessorID` (`ProfessorID` ASC),
  CONSTRAINT `FK_Courses_Departments`
    FOREIGN KEY (`DepartmentID`)
    REFERENCES `University`.`Departments` (`DepartmentID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Courses_Professors`
    FOREIGN KEY (`ProfessorID`)
    REFERENCES `University`.`Professors` (`ProfessorID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Students` (
  `StudentID` INT NOT NULL AUTO_INCREMENT,
  `StudentFirstName` VARCHAR(50) NOT NULL,
  `StudentLastName` VARCHAR(50) NOT NULL,
  `FacultyID` INT NOT NULL,
  PRIMARY KEY (`StudentID`, `FacultyID`),
  INDEX `IX_Students_FacultyID` (`FacultyID` ASC),
  CONSTRAINT `FK_Students_Faculties`
    FOREIGN KEY (`FacultyID`)
    REFERENCES `University`.`Faculties` (`FacultyID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Titles` (
  `TitleID` INT NOT NULL AUTO_INCREMENT,
  `TitleName` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`TitleID`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Students_Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Students_Courses` (
  `StudentID` INT NOT NULL,
  `CourseID` INT NOT NULL,
  PRIMARY KEY (`StudentID`, `CourseID`),
  INDEX `IX_Students_Courses_CourseID` (`CourseID` ASC),
  INDEX `IX_Students_Courses_StudentID` (`StudentID` ASC),
  CONSTRAINT `FK_Students_Courses_Students`
    FOREIGN KEY (`StudentID`)
    REFERENCES `University`.`Students` (`StudentID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Students_Courses_Courses`
    FOREIGN KEY (`CourseID`)
    REFERENCES `University`.`Courses` (`CourseID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `University`.`Professors_Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `University`.`Professors_Titles` (
  `Professors_ProfessorID` INT NOT NULL,
  `Titles_TitleID` INT NOT NULL,
  PRIMARY KEY (`Professors_ProfessorID`, `Titles_TitleID`),
  INDEX `IX_Professors_Titles_TitleID` (`Titles_TitleID` ASC),
  INDEX `IX_Professors_Titles_ProfessorID` (`Professors_ProfessorID` ASC),
  CONSTRAINT `FK_Professors_Titles_Professors`
    FOREIGN KEY (`Professors_ProfessorID`)
    REFERENCES `University`.`Professors` (`ProfessorID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `FK_Professors_Titles_Titles`
    FOREIGN KEY (`Titles_TitleID`)
    REFERENCES `University`.`Titles` (`TitleID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
