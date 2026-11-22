using System;
using System.Windows.Forms;
using BLL;
using DAL;

namespace WinFormUI
{
    public partial class StudentForm : Form
    {
        private readonly StudentService _studentService;

        public StudentForm()
        {
            InitializeComponent();
            _studentService = new StudentService();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            if (cboGender.Items.Count > 0)
            {
                cboGender.SelectedIndex = 0;
            }
            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                var students = _studentService.GetAllStudents();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtStudentCode.Text))
                {
                    MessageBox.Show("Please enter student code!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    MessageBox.Show("Please enter student full name!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var student = new Student
                {
                    StudentCode = txtStudentCode.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    DateOfBirth = dtpDob.Value.Date,
                    Gender = cboGender.SelectedItem?.ToString() ?? "Male",
                    Email = txtEmail.Text.Trim(),
                    Major = txtMajor.Text.Trim()
                };

                _studentService.AddStudent(student);
                MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding student: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = null;
                if (int.TryParse(txtStudentId.Text.Trim(), out int studentId))
                {
                    student = _studentService.GetStudent(studentId);
                }
                else if (!string.IsNullOrWhiteSpace(txtStudentCode.Text))
                {
                    student = _studentService.GetStudentByCode(txtStudentCode.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Please enter Student ID or Student Code to search!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (student != null)
                {
                    txtStudentId.Text = student.Id.ToString();
                    txtStudentCode.Text = student.StudentCode;
                    txtFullName.Text = student.FullName;
                    dtpDob.Value = student.DateOfBirth;
                    cboGender.SelectedItem = student.Gender;
                    txtEmail.Text = student.Email;
                    txtMajor.Text = student.Major;
                }
                else
                {
                    MessageBox.Show("Student not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving student: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtStudentId.Text.Trim(), out int studentId))
                {
                    MessageBox.Show("Please select or enter a valid Student ID to update!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var student = new Student
                {
                    Id = studentId,
                    StudentCode = txtStudentCode.Text.Trim(),
                    FullName = txtFullName.Text.Trim(),
                    DateOfBirth = dtpDob.Value.Date,
                    Gender = cboGender.SelectedItem?.ToString() ?? "Male",
                    Email = txtEmail.Text.Trim(),
                    Major = txtMajor.Text.Trim()
                };

                _studentService.UpdateStudent(student);
                MessageBox.Show("Student updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating student: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtStudentId.Text.Trim(), out int studentId))
                {
                    MessageBox.Show("Please select or enter a valid Student ID to delete!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("Are you sure you want to delete this student?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    _studentService.DeleteStudent(studentId);
                    MessageBox.Show("Student deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadStudents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting student: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadStudents();
        }

        private void ClearInputs()
        {
            txtStudentId.Clear();
            txtStudentCode.Clear();
            txtFullName.Clear();
            dtpDob.Value = DateTime.Today;
            if (cboGender.Items.Count > 0)
            {
                cboGender.SelectedIndex = 0;
            }
            txtEmail.Clear();
            txtMajor.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                if (row.Cells["Id"] != null && row.Cells["Id"].Value != null)
                {
                    txtStudentId.Text = row.Cells["Id"].Value.ToString();
                    txtStudentCode.Text = row.Cells["StudentCode"]?.Value?.ToString() ?? "";
                    txtFullName.Text = row.Cells["FullName"]?.Value?.ToString() ?? "";
                    if (row.Cells["DateOfBirth"]?.Value is DateTime dob)
                    {
                        dtpDob.Value = dob;
                    }
                    cboGender.SelectedItem = row.Cells["Gender"]?.Value?.ToString() ?? "Male";
                    txtEmail.Text = row.Cells["Email"]?.Value?.ToString() ?? "";
                    txtMajor.Text = row.Cells["Major"]?.Value?.ToString() ?? "";
                }
            }
        }
    }
}
