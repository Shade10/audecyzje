﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Audecyzje.WebQuickDemo.Data;
using Audecyzje.WebQuickDemo.Models;
using System.Text.RegularExpressions;
using Audecyzje.Core.Domain;
using Audecyzje.Infrastructure;

namespace Audecyzje.WebQuickDemo.Controllers
{
    public class TagsController : Controller
    {
        private readonly WarsawContext _context;
        private StaticDecisionContainer _staticContext;

        public TagsController(WarsawContext context)
        {
            _context = context;
            _staticContext = StaticDecisionContainer.GetInstance(context);
            
        }

        // GET: Tags
        public async Task<IActionResult> Index()
        {
            return View(_staticContext.Tags.ToList());
        }

        public async Task<IActionResult> ClearAllTagRelations()
        {
            var dgs = _context.DecisionTags.ToList();
            foreach (var dg in dgs)
            {
                _context.DecisionTags.Remove(dg);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CheckAllDecisionsContentWithTagsRegexp()
        {
            
            //var tags = await _context.Tags.Where(x => x.RegExp != null).ToListAsync();
            //var decisions = await _context.Descisions.ToListAsync();
            //foreach (var tag in tags)
            //{
            //    foreach (var dec in decisions)
            //    {
            //        var regexp = tag.RegExp;
            //        if (Regex.IsMatch(dec.Content, regexp, RegexOptions.IgnoreCase))
            //        {
            //            DecisionTag dt = new DecisionTag()
            //            {
            //                DecisionID = dec.ID,
            //                TagID = tag.ID
            //            };
            //            _context.DecisionTags.Add(dt);
            //        }
            //    }
            //    await _context.SaveChangesAsync();
            //}
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RecreateTags()
        {
            _staticContext.RecreateAllTags();
            //await ClearAllTagRelations();
            //await CheckAllDecisionsContentWithTagsRegexp();
            return RedirectToAction("Index");
        }
        // GET: Tags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var tag = await _context.Tags
                .Include(t => t.LinkedDecisions).ThenInclude(link => link.Decision)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // GET: Tags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TagName,RegExp")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(tag);
                //await _context.SaveChangesAsync();
                //await RecreateSingleTag(tag.ID);
                _staticContext.AddTag(tag);
                _staticContext.RecreateSingleTag(tag.Id);
                return RedirectToAction(nameof(Index));
            }
            return View(tag);
        }

        // GET: Tags/Edit/5

        public async Task<IActionResult> RecreateSingleTag(int? id)
        {
            _staticContext.RecreateSingleTag(id);
            //Tag tag = await _context.Tags.SingleAsync(x => x.ID == id);
            //if (tag != null)
            //{
            //    var decisions = _context.Descisions.ToList();
            //    var newDecisionTags = new List<DecisionTag>();
            //    foreach (var dec in decisions)
            //    {
            //        var regexp = tag.RegExp;
            //        if (Regex.IsMatch(dec.Content, regexp, RegexOptions.IgnoreCase))
            //        {
            //            DecisionTag dt = new DecisionTag()
            //            {
            //                DecisionID = dec.ID,
            //                TagID = tag.ID
            //            };
            //            newDecisionTags.Add(dt);
            //        }
            //    }
            //    var existing = _context.DecisionTags.Where(x => x.TagID == tag.ID);
            //    if (existing.Count() == 0)
            //    {
            //        _context.AddRange(newDecisionTags);
            //    }
            //    else
            //    {
            //        _context.DecisionTags.RemoveRange(existing);
            //        await _context.SaveChangesAsync();
            //        _context.DecisionTags.AddRange(newDecisionTags);
            //    }
            //    await _context.SaveChangesAsync();
            //}
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            //todo przerobić na staticcontext?
            if (id == null)
            {
                return NotFound();
            }

            var tag = _staticContext.Tags.Where(x => x.Id == id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TagName,RegExp")] Tag tag)
        {
            //todo przerobić na staticcontext?
            if (id != tag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(tag);
                    //await _context.SaveChangesAsync();

                    _staticContext.UpdateTag(tag);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagExists(tag.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tag);
        }

        // GET: Tags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tags
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var tag = await _context.Tags.SingleOrDefaultAsync(m => m.ID == id);
            //_context.Tags.Remove(tag);
            //await _context.SaveChangesAsync();

            _staticContext.RemoveTag(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TagExists(int id)
        {
            return _staticContext.Tags.Any(e => e.Id == id);
        }
    }
}
