import unittest
from pathlib import Path
from . import file_generator as fg
from components import file_parser as fp
#from .context import components


class TestFileParser(unittest.TestCase):

    def setUp(self):
        self.path = Path("input")
        self.csv50Filename = self.path / "csv_50.txt"
        self.pipe50Filename = self.path / "pipe_50.txt"
        self.space50Filename = self.path / "space_50.txt"
        self.largeCsv = self.path / "csv_large.txt"

        generator = fg.FileGenerator()

        if self.csv50Filename.is_file() == False:
            generator.generate(self.csv50Filename, 50, ",")

        if self.pipe50Filename.is_file() == False:
            generator.generate(self.pipe50Filename, 50, "|")

        if self.space50Filename.is_file() == False:
            generator.generate(self.space50Filename, 50, " ")

        if self.largeCsv.is_file() == False:
            generator.generate(self.largeCsv, 10000000, ",")

    def test_Parse_Csv(self):
        parser = fp.FileParser()
        people = parser.parse(self.csv50Filename)

        self.assertIsNotNone(people)
        self.assertEqual(len(people), 50)

    def test_Parse_Psv(self):
        parser = fp.FileParser()
        people = parser.parse(self.pipe50Filename)

        self.assertIsNotNone(people)
        self.assertEqual(len(people), 50)

    def test_Parse_Ssv(self):
        parser = fp.FileParser()
        people = parser.parse(self.space50Filename)

        self.assertIsNotNone(people)
        self.assertEqual(len(people), 50)

    def test_Parse_LargeFile(self):
        parser = fp.FileParser()
        people = parser.parse(self.largeCsv)

        self.assertIsNotNone(people)
        self.assertEqual(len(people), 10000000)

    def test_Parse_Bad_Input_Csv(self):
        parser = fp.FileParser()
        people = parser.parse(self.path / "comma_bad_input.txt")

        self.assertIsNotNone(people)
        self.assertEqual(len(people), 2)

    def test_Parse_Bad_Input_Ssv(self):
        parser = fp.FileParser()
        people = parser.parse(self.path / "space_bad_input.txt")

        self.assertIsNotNone(people)
        self.assertEqual(len(people), 2)

    def test_Parse_Bad_Input_Psv(self):
        parser = fp.FileParser()
        people = parser.parse(self.path / "pipe_bad_input.txt")

        self.assertIsNotNone(people)
        self.assertEqual(len(people), 3)


if __name__ == '__main__':
    unittest.main()
