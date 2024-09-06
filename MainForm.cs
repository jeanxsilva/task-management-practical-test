using System.Windows.Forms;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager
{
    public partial class MainForm : Form
    {
        private readonly ITaskService _taskService;
        private static bool _isInitialized = false;

        public MainForm(ITaskService service)
        {
            this._taskService = service;

            InitializeComponent();

            refreshListBox();

            _isInitialized = true;
        }

        private void refreshListBox()
        {
            List<TaskModel> tasks = this._taskService.GetAll();

            lbTasks.DataSource = tasks;
            lbTasks.ValueMember = "Id";
            lbTasks.DisplayMember = "DescriptionWithStatus";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(this.tbDescription.Text))
                {
                    this._taskService.Insert(new TaskModel()
                    {
                        Description = this.tbDescription.Text,
                        Status = TaskStatusEnum.New
                    });

                    refreshListBox();
                }
                else
                {
                    this.lblFeedback.ForeColor = Color.Red;
                    this.lblFeedback.Text = string.Format("É necessário preencher uma descrição válida para inserir uma nova tarefa!");
                }
            }
            catch (Exception ex)
            {
                this.lblFeedback.ForeColor = Color.Red;
                this.lblFeedback.Text = string.Format("Ocorreu um erro ao tentar inserir uma nova tarefa. Por favor, tente novamente!");
            }
        }

        private void buttonRunning_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lbTasks.SelectedValue != null)
                {
                    this._taskService.Update(new TaskModel()
                    {
                        Id = Convert.ToInt32(this.lbTasks.SelectedValue),
                        Status = TaskStatusEnum.Running
                    });

                    refreshListBox();
                }
                else
                {
                    this.lblFeedback.ForeColor = Color.Red;
                    this.lblFeedback.Text = string.Format("É necessário selecionar uma tarefa para iniciar!");
                }
            }
            catch (Exception ex)
            {
                this.lblFeedback.ForeColor = Color.Red;
                this.lblFeedback.Text = string.Format("Ocorreu um erro ao tentar iniciar a tarefa. Por favor, tente novamente!");
            }
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lbTasks.SelectedValue != null)
                {
                    this._taskService.Update(new TaskModel()
                    {
                        Id = Convert.ToInt32(this.lbTasks.SelectedValue),
                        Status = TaskStatusEnum.Concluded
                    });

                    refreshListBox();
                }
                else
                {
                    this.lblFeedback.ForeColor = Color.Red;
                    this.lblFeedback.Text = string.Format("É necessário selecionar uma tarefa para finalizar uma tarefa!");
                }
            }
            catch (Exception ex)
            {
                this.lblFeedback.ForeColor = Color.Red;
                this.lblFeedback.Text = string.Format("Ocorreu um erro ao tentar finalizar a tarefa. Por favor, tente novamente!");
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lbTasks.SelectedValue != null)
                {
                    this._taskService.Delete(Convert.ToInt32(this.lbTasks.SelectedValue));

                    refreshListBox();
                }
                else
                {
                    this.lblFeedback.ForeColor = Color.Red;
                    this.lblFeedback.Text = string.Format("É necessário selecionar uma tarefa para deletar uma tarefa!");
                }
            }
            catch (Exception ex)
            {
                this.lblFeedback.ForeColor = Color.Red;
                this.lblFeedback.Text = string.Format("Ocorreu um erro ao tentar deletar a tarefa. Por favor, tente novamente!");
            }
        }

        private void lbTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitialized && this.lbTasks.SelectedValue != null)
            {
                TaskModel task = this._taskService.GetById(Convert.ToInt32(this.lbTasks.SelectedValue));
                if (task != null)
                {
                    switch (task.Status)
                    {
                        case TaskStatusEnum.New:
                            buttonRun.Visible = true;
                            buttonRun.Enabled = true;
                            break;
                        case TaskStatusEnum.Running:
                            buttonFinish.Visible = true;
                            buttonFinish.Enabled = true;
                            break;
                        default:
                            buttonFinish.Visible = false;
                            buttonRun.Visible = false;
                            break;
                    }

                    buttonRemove.Enabled = true;
                }
            }
        }

        private void tbDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (!buttonAdd.Enabled && tbDescription.Text.Length > 0)
            {
                buttonAdd.Enabled = true;
            }
        }
    }
}
