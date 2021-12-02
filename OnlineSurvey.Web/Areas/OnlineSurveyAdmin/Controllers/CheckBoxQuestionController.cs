using OnlineSurvey.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSurvey.ViewModel;
using OnlineSurvey.Model;

namespace OnlineSurvey.Web.Areas.OnlineSurveyAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CheckBoxQuestionController : Controller
    {
        private readonly IUnitOfWork uow;

        public CheckBoxQuestionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
       
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCheckBoxQuestionData()
        {
            var checkBoxquestion = uow.CheckBoxQuestionRepository.GetAll("CheckBoxAnswers").ToList();

            List<CheckBoxShowViewModel> viewmodel = new List<CheckBoxShowViewModel>();

            var checkboxAnswerId = new List<int>();
            var checkBoxName = new List<string>();

            foreach (var item in checkBoxquestion)
            {
                checkboxAnswerId = item.CheckBoxAnswers.Select(x => x.Id).ToList();

                checkBoxName = item.CheckBoxAnswers.Where(x => checkboxAnswerId.Contains(x.Id)).Select(x => x.Answer).ToList();

                viewmodel.Add(new CheckBoxShowViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    IsActive=item.IsActive,
                    Question=item.Question,
                    CheckoxString=checkBoxName,
                    IsTypeCheckbox=item.IsTypeCheckbox,
                    IsTypeRadioButton=item.IsTypeRadioButton,
                });
            }
            return Json(new
            {


                data = viewmodel,

            }, JsonRequestBehavior.AllowGet);
           
        }

        [HttpGet]
        public ActionResult Create()
        {

            var checkBoxQuestion = uow.CheckBoxAnswerRepository.GetAll().ToList();
            CheckboxQuestionViewModel viewmodel = new CheckboxQuestionViewModel();

            List<CheckBoxItemForQuestionViewModel> checkbox = new List<CheckBoxItemForQuestionViewModel>();

            foreach (var item in checkBoxQuestion)
            {
                checkbox.Add(new CheckBoxItemForQuestionViewModel
                {
                    Id=item.Id,
                    Text=item.Answer,
                    Checked=false,
                    
                });

            }
            viewmodel.CheckBoxItems = checkbox;
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Title,Question,IsActive,CheckBoxAnswers,IsTypeCheckbox,IsTypeRadioButton")] CheckboxQuestionViewModel viewmodel, int[] CheckBoxItems)
        {
            if(ModelState.IsValid)
            {
                var checkboxQuestion = new CheckBoxQuestions
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Question=viewmodel.Question,
                    IsActive=viewmodel.IsActive,
                    CheckBoxAnswers=viewmodel.CheckBoxAnswers,
                    IsTypeCheckbox=viewmodel.IsTypeCheckbox,
                    IsTypeRadioButton=viewmodel.IsTypeRadioButton,
                   
                };

                //int[] checkboxItemId = uow.Context.CheckBoxAnswers.Select(x => x.Id).ToArray();

                var checkboxAnswer =uow.Context.CheckBoxAnswers.Where(x => CheckBoxItems.Contains(x.Id)).Select(x => x.Id).ToList();


                foreach(var item in checkboxAnswer)
                {
                    var CheckboxId = uow.CheckBoxAnswerRepository.GetById(item);
                    checkboxQuestion.CheckBoxAnswers.Add(CheckboxId);
                }
               



                uow.CheckBoxQuestionRepository.Add(checkboxQuestion);
                uow.Commit();
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var editResult = GetEditCheckBox(id);
            return View(editResult);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Title,Question,IsActive,CheckBoxAnswers,IsTypeCheckbox,IsTypeRadioButton")] EditCheckboxQuestionViewModel viewmodel,int[] CheckBoxItems)
        {
            if(ModelState.IsValid)
            {
                var checkboxQuestion = uow.Context.CheckBoxQuestions.Include("CheckBoxAnswers").Where(x => x.Id == viewmodel.Id).FirstOrDefault();

                
                if(checkboxQuestion !=null)
                {
                    int[] currentAnswer = checkboxQuestion.CheckBoxAnswers.Select(x => x.Id).ToArray();
                    var answerName = uow.Context.CheckBoxAnswers.Where(x => currentAnswer.Contains(x.Id)).Select(x => x.Id).ToArray();

                    foreach (var item in answerName)
                    {
                        var name = uow.CheckBoxAnswerRepository.GetById(item);

                        checkboxQuestion.CheckBoxAnswers.Remove(name);
                    }

                   
                    checkboxQuestion.Id = viewmodel.Id;
                    checkboxQuestion.Question = viewmodel.Question;
                    checkboxQuestion.Title = viewmodel.Title;
                    checkboxQuestion.IsActive = viewmodel.IsActive;
                    checkboxQuestion.CheckBoxAnswers = viewmodel.CheckBoxAnswers;
                    checkboxQuestion.IsTypeRadioButton = viewmodel.IsTypeRadioButton;
                    checkboxQuestion.IsTypeCheckbox = viewmodel.IsTypeCheckbox;
                    if(CheckBoxItems != null)
                    {
                        var requiredAnswer = uow.Context.CheckBoxAnswers.Where(x => CheckBoxItems.Contains(x.Id)).ToList();

                        foreach (var item in requiredAnswer)
                        {
                            viewmodel.CheckBoxAnswers.Add(item);
                            checkboxQuestion.CheckBoxAnswers.Add(item);
                        }
                       
                    }

                    uow.CheckBoxQuestionRepository.Update(checkboxQuestion);
                    uow.Commit();

                }
               
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var deleteCheckboxQuestion = GetEditCheckBox(id);
            return View(deleteCheckboxQuestion);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmeDelete(int id)
        {
            var deleteCheckBoxQuestion = uow.Context.CheckBoxQuestions.Include("CheckBoxAnswers").Where(x => x.Id == id).FirstOrDefault();

            uow.CheckBoxQuestionRepository.Remove(deleteCheckBoxQuestion);
            uow.Commit();
            return RedirectToAction(nameof(Index));
        }
        private EditCheckboxQuestionViewModel GetEditCheckBox(int id)
        {
            var checkboxQuestion = uow.Context.CheckBoxQuestions.Include("CheckBoxAnswers").Where(x => x.Id == id).FirstOrDefault();
            
            int[] checkBoxAnswer = checkboxQuestion.CheckBoxAnswers.Select(x => x.Id).ToArray();
            var curretnAnswer = checkboxQuestion.CheckBoxAnswers.Select(x => x.Id).ToList();

            var allAnswers = uow.Context.CheckBoxAnswers.ToList();

            EditCheckboxQuestionViewModel editCheckbox = new EditCheckboxQuestionViewModel();

            editCheckbox.Title = checkboxQuestion.Title;
            editCheckbox.Question = checkboxQuestion.Question;
            editCheckbox.IsActive = checkboxQuestion.IsActive;
            editCheckbox.IsTypeCheckbox = checkboxQuestion.IsTypeCheckbox;
            editCheckbox.IsTypeCheckbox = checkboxQuestion.IsTypeCheckbox;
           

            foreach(var item in allAnswers)
            {
                if (curretnAnswer.Contains(item.Id))
                {
                    editCheckbox.CheckBoxItems.Add(new CheckBoxItemForQuestionViewModel { Id = item.Id, Text = item.Answer, Checked = true });
                }
                else
                {
                    editCheckbox.CheckBoxItems.Add(new CheckBoxItemForQuestionViewModel { Id = item.Id, Text = item.Answer, Checked = false });
                }
            }

            return editCheckbox;
            
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var detailsCheckboxQuestion = GetEditCheckBox(id);
            return View(detailsCheckboxQuestion);
        }
    }
}